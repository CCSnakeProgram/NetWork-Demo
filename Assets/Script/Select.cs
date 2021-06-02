using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Select : MonoBehaviour
{
    public void ClonePink()
    {
        PhotonNetwork.Instantiate("Pink",new Vector3(-2, 2.7f, 0), Quaternion.identity);
    }
    
    public void CloneBlue()
    {
        PhotonNetwork.Instantiate("Blue",new Vector3(-2, 2.7f, 0), Quaternion.identity);
    }
    
    public void CloneGreen()
    {
        PhotonNetwork.Instantiate("Green",new Vector3(-2, 2.7f, 0), Quaternion.identity);
    }
    
    public void CloneMask()
    {
        PhotonNetwork.Instantiate("Mask",new Vector3(-2, 2.7f, 0), Quaternion.identity);
    }
}
