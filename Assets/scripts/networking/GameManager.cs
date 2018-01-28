using UnityEngine;
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
    
    public void OnPlayerDeathTransform(GameObject player, NetworkConnection conn , int kills, int deaths , bool ToRaptor = true)
    {
        //GameObject newPlayer;
        //if (ToRaptor)
        //    newPlayer = Instantiate<GameObject>(BirdController);
        //else
        //    newPlayer = Instantiate<GameObject>(RobotController);

        //PlayerUnet newPlayerUnet = newPlayer.GetComponent<PlayerUnet>();
        //playerScore newPlayerScore = newPlayer.GetComponent<playerScore>();
        
        //newPlayer.transform.position = rebornTransform.position;
        //newPlayer.transform.rotation = rebornTransform.rotation;
        
        
        //Destroy(player);
        //invoco el metodo para reemplazar el jugador, en el local player el clientcontroller id es = 0
        //NetworkServer.ReplacePlayerForConnection(conn, newPlayer, 0);

    }

    private void FixedUpdate()
    {
        Puntaje++;
        //check if is game over, if that true enables the gameover screen and 
        if (isGameOver)
        {
            if(GetComponent<GameManager>().GameOverScreen.activeInHierarchy == false)
            {
                GetComponent<GameManager>().GameOverScreen.SetActive(true);
            }

            if (CrossPlatformInputManager.GetButtonDown("Enter") && isServer)
                NetworkManager.singleton.ServerChangeScene("Nivel1");
        }
    }

}
