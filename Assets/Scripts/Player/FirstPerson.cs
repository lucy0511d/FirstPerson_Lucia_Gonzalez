using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPerson : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private TMP_Text textoVida;

    [Header("Puntuacion")]
    [SerializeField] TMP_Text textoPuntuacion;
    private int puntuacion;

    [Header("Audio")]
    [SerializeField] AudioClip salto;
    [SerializeField] AudioClip muerte;
    [SerializeField] AudioManager managers;

    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] private float alturaSalto;
    [SerializeField] private float escalaGravedad;

    [Header("Detección del suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;
    
    CharacterController controller;
    private Vector3 movimientoVertical;
    

    void Start()
    {
        // bloquea el raton y lo oculta
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
        textoPuntuacion.SetText("Puntuacion: " + puntuacion);
        textoVida.SetText("Vida: " + vida);

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // no sirve: Vector3 movimiento = new Vector3(h, 0, v).normalized;

        Vector2 input = new Vector2 (h, v).normalized;
        if (input.magnitude > 0)
        {
            // se calcula el angulo al que tengo que rotarme en funcion de los inputs y orientacion de camara
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * velocidad * Time.deltaTime);
        }
        DeteccionSuelo();
        AplicarGravedad();
        MoverYRotar();



    }
    private void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector3 (0, Camera.main.transform.eulerAngles.y, 0);
    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }
    private void DeteccionSuelo()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, queEsSuelo);
        if (collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }
    private void Saltar()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
            managers.ReproducirSonidoSalto(salto);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(pies.position, radioDeteccion);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("ParteEnemigo"))
        {
            Vector3 direccionFuerza = hit.transform.position - transform.position; //transform.position es la posicion de este gameobject
            Rigidbody rbEnemigo = hit.gameObject.GetComponent<Rigidbody>();
            rbEnemigo.AddForce(direccionFuerza.normalized * 50, ForceMode.Impulse);
        }
    }
    public void RecibirDanho(float danhoRecibido)
    {
        vida -= danhoRecibido;
        if(vida <= 0)
        {
            Destroy(gameObject);
            managers.ReproducirSonidoMuerte(muerte);
            SceneManager.LoadScene(2);
        }
    }
   
}
