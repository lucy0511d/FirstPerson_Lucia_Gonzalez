using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploCorrutinas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Coroutine llamada1 = StartCoroutine(SemaforoInfinito());
        Coroutine llamada2 = StartCoroutine(SemaforoInfinito());
        Coroutine llamada3 = StartCoroutine(SemaforoInfinito());
        Coroutine llamada4 = StartCoroutine(SemaforoInfinito());
        Coroutine llamada5 = StartCoroutine(SemaforoInfinito());
        StopCoroutine(llamada1);
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SemaforoInfinito()
    {
        while(1 == 1)
        {
            Debug.Log("Verde");
            yield return new WaitForSeconds(2);
            Debug.Log("Amarillo");
            yield return new WaitForSeconds(3);
            Debug.Log("Rojo");
        }
       
    }
}
