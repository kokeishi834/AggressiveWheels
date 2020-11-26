using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class StageController : MonoBehaviourPunCallbacks
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("AW_GameRoom", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("join room");
        // マッチング後、自分自身のネットワークオブジェクトを生成する
        PhotonNetwork.Instantiate(obj.name, new Vector3(0.0f,-6.0f,0.0f), Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
