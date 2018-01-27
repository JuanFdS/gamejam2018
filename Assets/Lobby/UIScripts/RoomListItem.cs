using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class RoomListItem : MonoBehaviour {
    [SerializeField]
    private Text roomNameText;
    private MatchInfoSnapshot match;
    public delegate void JoinRoomDelegate(MatchInfoSnapshot _match);
    public JoinRoomDelegate joinRoomCallback;

    public void Setup(MatchInfoSnapshot _match, JoinRoomDelegate _joinRoomCallback)
    {
        match = _match;
        joinRoomCallback = _joinRoomCallback;
        roomNameText.text = match.name + "("+match.currentSize +"/"+ match.maxSize + ")";
    }

    public void joinRoom()
    {
        joinRoomCallback.Invoke(match);
    }
	
}
