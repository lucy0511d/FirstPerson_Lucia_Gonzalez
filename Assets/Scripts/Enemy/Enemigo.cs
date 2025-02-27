using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    [Header("Ataque")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private int radioAtaque;
    [SerializeField] private float vidas;
    [SerializeField] Rigidbody[] huesos;
    private bool danhoRealizado = false;
    private NavMeshAgent agent;
    private FirstPerson player;
    private Animator anim;
    private bool ventanaAbierta = false;
    private static int victoria;
    public float Vidas { get => vidas; set => vidas = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        huesos = GetComponentsInChildren<Rigidbody>();
        CambiarEstadoHuesos(true);
    }


    void Update()
    {
        Perseguir();

        if (ventanaAbierta && danhoRealizado == false)
        {
            DetectarJugador();
        }


    }

    private void Perseguir()
    {
        //Tengo que definir como destino la posicion del Player.
        agent.SetDestination(player.transform.position);
        //Si no hay calculos pendientes para saber donde está mi objetivo (agent.pathpending)
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            //Me paro ante él
            agent.isStopped = true;
            anim.SetBool("attacking", true);
            EnfocarPlayer();
        }
        else
        {
            agent.isStopped = false;
            anim.SetBool("attacking", false);
        }
    }

    private void EnfocarPlayer()
    {
        Vector3 direccionAPlayer = (player.transform.position - transform.position).normalized;
        direccionAPlayer.y = 0;
        transform.rotation = Quaternion.LookRotation(direccionAPlayer);
    }

    private void DetectarJugador()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);
        if (collsDetectados.Length > 0)
        {
            for (int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);
            }
            danhoRealizado = true;
            
        }
    }
    public void Morir()
    {
        agent.enabled = false;
        anim.enabled = false;
        CambiarEstadoHuesos(false);
        victoria++;
        if (victoria > 5)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void CambiarEstadoHuesos(bool estado)
    {
        for(int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }

    #region Eventos de animacion
    private void FinAtaque()
    {
        //Cuando termino de atacar, vuelvo a moverme
        agent.isStopped = true;
        danhoRealizado = false;
        anim.SetBool("attacking", false);
    }
    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
    #endregion
}
