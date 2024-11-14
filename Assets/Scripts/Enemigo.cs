using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float danhoAtaque;
    private NavMeshAgent agent;
    private FirstPerson player;
    private Animator anim;
    private bool ventanaAbierta = false;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private int radioAtaque;
    private bool danhoRealizado = false;
    [SerializeField] private float vidas;
    [SerializeField] Rigidbody[] huesos;

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
        agent.SetDestination(player.transform.position);
        //Si no hay calculos pendientes para saber donde está mi objetivo (agent.pathpending)
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attacking", true);
        }
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
    }
    private void CambiarEstadoHuesos(bool estado)
    {
        for(int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }


    private void FinAtaque()
    {
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
    
}
