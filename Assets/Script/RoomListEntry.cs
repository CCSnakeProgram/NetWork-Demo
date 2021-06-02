using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoomListEntry : MonoBehaviourPunCallbacks
{
    public Text RoomNameText;
    private Button JoinRoomButton;
    private string roomName;
    private void Start()
    {
        JoinRoomButton.onClick.AddListener(() =>
        {
            PhotonNetwork.JoinRoom(roomName);
        });
        JoinRoomButton = GetComponent<Button>();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="RoomName">房间名字</param>
    public void Initialize(string RoomName)
    {
        roomName = RoomName;
        RoomNameText.text = RoomName;
    }
}
