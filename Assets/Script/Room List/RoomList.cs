using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject RoomListPrefabs;

    public Transform RoomListPrefabsFather;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < RoomListPrefabsFather.childCount; i++)
        {
            if (RoomListPrefabsFather.GetChild(i).gameObject.GetComponentInChildren<Text>().text !=
                roomList[i].Name) continue;
            Destroy(RoomListPrefabsFather.GetChild(i).gameObject);
            if (roomList[i].PlayerCount == 0)
            {
                roomList.Remove(roomList[i]);
            }
        }
        foreach (var room in roomList)
        {
            var CreateRoom = Instantiate(RoomListPrefabs, RoomListPrefabsFather.position, Quaternion.identity);
            CreateRoom.GetComponent<RoomListEntry>().Initialize(room.Name);
            CreateRoom.transform.SetParent(RoomListPrefabsFather,false);
        }
    }
}
