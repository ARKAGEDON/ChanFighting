// vis2k: GUILayout instead of spacey += ...; removed Update hotkeys to avoid
// confusion if someone accidentally presses one.
using System.ComponentModel;
using UnityEngine;
using TMPro;

namespace Mirror
{
    /// <summary>
    /// An extension for the NetworkManager that displays a default HUD for controlling the network state of the game.
    /// <para>This component also shows useful internal state for the networking system in the inspector window of the editor. It allows users to view connections, networked objects, message handlers, and packet statistics. This information can be helpful when debugging networked games.</para>
    /// </summary>
    [RequireComponent(typeof(NetworkManager))]
    public class NetworkHUD : MonoBehaviour
    {
        NetworkManager manager;

        /// <summary>
        /// Whether to show the default control HUD at runtime.
        /// </summary>
        public bool showGUI = true;
        public bool StopC = false;

        /// <summary>
        /// The horizontal offset in pixels to draw the HUD runtime GUI at.
        /// </summary>
        public int offsetX;

        /// <summary>
        /// The vertical offset in pixels to draw the HUD runtime GUI at.
        /// </summary>
        public int offsetY;
        public TextMeshProUGUI ip;
       // public GameObject canvasNM;
        void Awake()
        {
            manager = GetComponent<NetworkManager>();
            //canvasNM.SetActive(true);
        }
        public void StartHost()
        {
            if (!NetworkClient.active)
            {
                manager.StartHost();
                //canvasNM.SetActive(false);
                //GameObject.FindGameObjectWithTag("LobbyCamera").SetActive(false);
            }
        }
        public void StartClient()
        {
            if (!NetworkClient.active)
            {
                ip = GameObject.FindGameObjectWithTag("IPText").GetComponent<TextMeshProUGUI>();
                manager.StartClient();
                Debug.Log(ip.text.ToString());
                manager.networkAddress = ip.text.ToString();
                //canvasNM.SetActive(false);
                //GameObject.FindGameObjectWithTag("LobbyCamera").SetActive(false);
            }
        }
        public void Server()
        {
            manager.StartServer();
            //canvasNM.SetActive(false);
            //GameObject.FindGameObjectWithTag("LobbyCamera").SetActive(false);
        }
        public void StopClient()
        {
            // stop host if host mode
            if (NetworkServer.active && NetworkClient.isConnected)
            {
                manager.StopHost();
                //GameObject.FindGameObjectWithTag("LobbyCamera").SetActive(true);
                //canvasNM.SetActive(true);
            }
            // stop client if client-only
            else if (NetworkClient.isConnected)
            {
                manager.StopClient();
                //GameObject.FindGameObjectWithTag("LobbyCamera").SetActive(true);
                //canvasNM.SetActive(true);
            }
            // stop server if server-only
            else if (NetworkServer.active)
            {
                manager.StopServer();
                //GameObject.FindGameObjectWithTag("LobbyCamera").SetActive(true);
                //canvasNM.SetActive(true);
            }
        }
    }
}
