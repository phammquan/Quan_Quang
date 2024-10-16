using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreatOrJoid : MonoBehaviourPunCallbacks
{
    public InputField _createInputField;
    public InputField _joidInputField;


    public void CreatRoom()
    {
        PhotonNetwork.CreateRoom(_createInputField.text);
    }
    public void JoidRoom()
    {
        PhotonNetwork.JoinRoom(_joidInputField.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GamePlay");
    }
}
