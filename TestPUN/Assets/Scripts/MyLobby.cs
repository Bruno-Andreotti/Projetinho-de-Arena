using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLobby : MonoBehaviourPunCallbacks
{
    public string PlayerName;
    public GameObject roomPanel;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainGame()
    {

        PhotonNetwork.LocalPlayer.NickName = PlayerName;
        PhotonNetwork.ConnectUsingSettings();

    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnConnectedToMaster()
    {
        roomPanel.SetActive(true);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Não encontrou sala. Criando nova...");
        string roomName = "Sala00";
        RoomOptions r0p = new RoomOptions();
        r0p.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(roomName, r0p);

    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Level1");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Jogador " + PlayerName + " entrou na sala");
    }
}
