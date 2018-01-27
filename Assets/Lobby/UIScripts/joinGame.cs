using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;


public class joinGame : MonoBehaviour {
    List<GameObject> roomList = new List<GameObject>();
    private NetworkManager networkManager;

    [SerializeField]
    private Text status;
    [SerializeField]
    private GameObject RoomListItemPrefab;
    [SerializeField]
    private Transform RoomListParent;
    private string ipAddress;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();            
        }
        RefreshRoomList();
    }    

    public void RefreshRoomList()
    {
        clearRoomList();
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        networkManager.matchMaker.ListMatches(0,20,"",true,0,0,OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList (bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        status.text = "";
        if (matchList == null)
        {
            status.text = "coulnd't get room list.";
            return;
        }
        
        foreach (MatchInfoSnapshot match in matchList)
        {
            GameObject _roomListItemGO = Instantiate(RoomListItemPrefab);
            _roomListItemGO.transform.SetParent(RoomListParent);

            //_roomListItem is an script that i added in the _roomListItemGO prefab and that deals with writing the name of the room and the current players.
            RoomListItem _roomListItem = _roomListItemGO.GetComponent<RoomListItem>();
            if(_roomListItem != null)
            {
                _roomListItem.Setup(match , JoinRoom);
            }
            //Setting up a callback function that will be called from the _roomListItemGO._roomListItem script joinGame.

            

            roomList.Add(_roomListItemGO);
        }
        if(roomList.Count == 0)
        {
            status.text = "No rooms available at the moment";
        }

    }

    void clearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }

    public void JoinRoom(MatchInfoSnapshot _match)
    {
        networkManager.matchMaker.JoinMatch(_match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        StartCoroutine(WaitForJoin());
    }

    IEnumerator WaitForJoin ()
    {
        int countDown = 20;
        while (countDown > 0)
        {
            clearRoomList();
            status.text = "Joining...("+ countDown + ")";

            yield return new WaitForSeconds(1);
            countDown--;
        }

        status.text = "Failed to join";
        yield return new WaitForSeconds(1.5f);

        MatchInfo matchInfo = networkManager.matchInfo;
        if(matchInfo != null)
        {
            networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
            networkManager.StopHost();
        }
        
        RefreshRoomList();
    }

    public void JoinLanGame()
    {
        networkManager.StopMatchMaker();
        if (ipAddress != "" && ipAddress != null)
        {
            networkManager.networkAddress = ipAddress;
        }
        else{
            networkManager.networkAddress = "localhost";
        }            
        networkManager.networkPort = 7777;
        //Network.Connect(ipAddress, networkManager.networkPort);
        networkManager.StartClient();
    }

    public void SetIpAddress(string _ipAddress)
    {
        ipAddress = _ipAddress;
    }

}
