﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : NetworkBehaviour {

    public static int Puntaje = 0;
    public GameObject GameOverScreen;
    public static bool isGameOver = false;
    public GameObject Relleno;
    public static GameObject LocalPlayer;
    public GameObject Robot;
    public GameObject Bird;
    public GameObject Observer;
    public static GameManager singletone;
    public static int CantidadJugadores;
    //Almaceno el si el jugador local es raptor o humano para que los jugadores remotos que se setean localmente puedan saber si activar o no su markador de radar.
    public static string LocalPlayerCharacter;
    [SerializeField]
    
    void Awake()
    {
        if (singletone != null)
        {
            Debug.LogError("More than one gameManager instanciated");
        }
        else
        {
            singletone = this;
        }

        LocalPlayer = Observer;
    }

    private void FixedUpdate()
    {
        Puntaje++;
        //check if is game over, if that true enables the gameover screen and 
        if (isGameOver)
        {
            if(GetComponent<GameManager>().GameOverScreen.activeInHierarchy == false)
            {
                StartCoroutine(GameOverAfterDie(2));
            }

            if (CrossPlatformInputManager.GetButtonDown("Enter") && isServer)
            {
                isGameOver = false;
                CmdReset();
                NetworkManager.singleton.ServerChangeScene("Nivel1");
            }
        }
    }

    [Command(channel = 0)]
    void CmdReset()
    {
        RpcClientReset();
    }

    [ClientRpc(channel = 0)]
    void RpcClientReset()
    {
        GameManager.isGameOver = false;
    }
    

    IEnumerator GameOverAfterDie(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        GetComponent<GameManager>().GameOverScreen.SetActive(true);
    }

}
