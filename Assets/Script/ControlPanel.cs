using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;


public class ControlPanel : MonoBehaviourPunCallbacks
{
    [Header("LoadServerPanel")]
    public GameObject LoadServerPanel;
    
    [Header("SelectPanel")] 
    public GameObject SelectPanel;
    
    [Header("LobbyPanel")]
    public GameObject LobbyPanel;
    
    [Header("OnCreateRoomPanel")]
    public GameObject OnCreateRoomButton;
    public InputField CreateInputField;
    public GameObject caveatTextPrefabs;
    
    [Header("OnSearchRoomPanel")]
    public GameObject OnSearchRoomButton;
    /// <summary>
    /// Play Button in the Load Server Panel
    /// </summary>
    public void PlayButton()
    {
        if (PhotonNetwork.InLobby)
        {
            LoadServerPanel.SetActive(false);
            SelectPanel.SetActive(true);
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }
        
    }
    
    /// <summary>
    /// Create Room Button in the Server Lobby
    /// </summary>
    public void CreateRoomButton()
    {
        SelectPanel.SetActive(false);
        OnCreateRoomButton.SetActive(true);
    }

    /// <summary>
    /// Search Room Button in the Server Lobby
    /// </summary>
    public void SearchRoomButton()
    {
        SelectPanel.SetActive(false);
        LobbyPanel.SetActive(true);
    }
    
    
    /// <summary>
    /// Select the Create Room Button in the Panel
    /// </summary>
    public void CreateRoomInSelectPanel()
    {
        if (CreateInputField.text.Length > 3)
        {
            var roomOptions = new RoomOptions {MaxPlayers = 20, IsVisible = true};
            PhotonNetwork.CreateRoom(CreateInputField.text,roomOptions,TypedLobby.Default);
        }
        else
        {
            var caveattext = Instantiate(caveatTextPrefabs, new Vector3(0,56,0), Quaternion.identity);
            caveattext.transform.SetParent(transform,false);
            caveattext.GetComponent<caveat>().SetText("请输入不少于3个字符!");
            Destroy(caveattext,1);
            CreateInputField.text = null;
        }
    }
}
