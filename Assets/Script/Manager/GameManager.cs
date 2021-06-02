using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject Bg;
    public Transform BgPos;
    public InputField NameInputField;
    public GameObject caveatTextPrefabs;
    public void BtnAll()
    {
        if (NameInputField.text.Length > 2)
        {
            PhotonNetwork.NickName = NameInputField.text;
            Bg.SetActive(false);
        }else
        {
            var caveattext = Instantiate(caveatTextPrefabs, new Vector3(0, 56, 0), Quaternion.identity);
            caveattext.transform.SetParent(BgPos, false);
            caveattext.GetComponent<caveat>().SetText("请输入不少于2个字符!");
            Destroy(caveattext, 1);
            NameInputField.text = null;
        }
    }
}
