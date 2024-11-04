using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject player;
    [Space]
    [SerializeField] Transform spawnPoint;

    void Start()
    {
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation);
    }
}
