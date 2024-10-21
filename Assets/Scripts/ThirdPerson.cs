using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private CharacterController controller;
    private Camera cam;
    private Animator anim;
    private float velocidadRotacion;
    [SerializeField] private float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        // bloquea el raton y lo oculta
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // no sirve: Vector3 movimiento = new Vector3(h, 0, v).normalized;

        Vector2 input = new Vector2(h, v).normalized;
        if (input.sqrMagnitude > 0)
        {
            // se calcula el angulo al que tengo que rotarme en funcion de los inputs y orientacion de camara
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smoothing);
            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }



    }
}
