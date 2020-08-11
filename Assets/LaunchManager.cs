using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LaunchManager : MonoBehaviour
{
    public void StartHost()
    {
        GameObject Network = GameObject.FindGameObjectWithTag("NetworkManager");
        Network.GetComponent<NetworkHUD>().StartHost();
    }
    public void StartClient()
    {
        GameObject Network = GameObject.FindGameObjectWithTag("NetworkManager");
        Network.GetComponent<NetworkHUD>().StartClient();
    }
}
