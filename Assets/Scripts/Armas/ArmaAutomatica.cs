using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        timer = misDatos.cadenciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque)
        {
            system.Play();

            //forward es z, right es  , up es 
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<EnemyPart>().RecibirDanho(misDatos.danhoAtaque);
                }

                // Debug.Log(hitInfo.transform.name);

            }
            timer = 0;
        }

    }
}

  
