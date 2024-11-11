using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private Enemigo enemigo;
    private float danho;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        enemigo = GetComponent<Enemigo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            system.Play();

            //forward es z, right es  , up es 
           if( Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
           {
                if ( hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);
                }
                
               // Debug.Log(hitInfo.transform.name);
                
           }
        }
    }
}
