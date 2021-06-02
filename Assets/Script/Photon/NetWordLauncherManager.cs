using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NetWordLauncherManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void OnConnectedToMaster()
    {
        PlayButtonAnimator.playButtonAnimator.PlayAnimator();
        PhotonNetwork.JoinLobby();
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public override void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    } 
}
