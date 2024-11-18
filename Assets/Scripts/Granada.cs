using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{   private Rigidbody rb;
    // private Transform posicionGranada;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float tiempoVida;
    [SerializeField] private int radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward.normalized * 2f, ForceMode.Impulse);
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {  
        Instantiate(explosionPrefab, transform.position,Quaternion.identity);
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioAtaque, queEsDanhable);
        if (collsDetectados.Length > 0)
        {
            Debug.Log("Hola");
        }
        Debug.Log("Me voy pa wiii");


    }
}
