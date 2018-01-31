using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Spectator : NetworkBehaviour {
	GameObject playerPrefab;
    public GameObject playerBird;
    public GameObject playerRobot;

    public override void OnStartClient()
    {
        GameManager.CantidadJugadores++;
    }
    public override void OnStartLocalPlayer()
    {
        Spawn();
    }

    public void Spawn(){
		if (isLocalPlayer) {
			Cmd_Spawn();
		}
	}
	[Command]
	void Cmd_Spawn(){
        if ((isLocalPlayer && !isServer) || !isLocalPlayer)
        {
            playerPrefab = playerRobot;
        }
        else
        {
            playerPrefab = playerBird;
            GameManager.singletone.disableEnergyBar();
        }
            

        GameObject player = (GameObject)Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        NetworkServer.Destroy(gameObject);
        NetworkServer.ReplacePlayerForConnection(connectionToClient, player, playerControllerId);
    }

}
