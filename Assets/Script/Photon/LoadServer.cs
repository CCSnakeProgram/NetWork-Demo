using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class LoadServer : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Screen.SetResolution(1366,768,false);
    }
}
