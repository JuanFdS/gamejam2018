using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Corrutinas : NetworkBehaviour {
    public static Corrutinas singletone;

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
    }

    //reloading scene when players die
    public void resetScene(string sceneName, int segundos)
    {
        StartCoroutine(ReloadingSceneTimed(sceneName, segundos));
    }
    IEnumerator ReloadingSceneTimed(string sceneName, int segundos)
    {

        yield return new WaitForSeconds(segundos);
        NetworkManager.singleton.ServerChangeScene(sceneName);

    }
}
