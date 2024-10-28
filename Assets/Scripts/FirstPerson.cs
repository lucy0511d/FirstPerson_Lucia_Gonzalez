using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [Header("Detección del suelo")]
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private float escalaGravedad;
    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    private Vector3 movimientoVertical;

    // Start is called before the first frame update
    void Start()
    {
        // bloquea el raton y lo oculta
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
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

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        DeteccionSuelo();
        AplicarGravedad();
        
        

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
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}
