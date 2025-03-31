using NUnit.Framework;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System;

public class NetworManagerScript : MonoBehaviour
{
    private class NetworkPlayer
    {
        public GameObject GameObject;
        public int id;
    }

    private List<NetworkPlayer> players;
    public GameObject overNetworkPlayerPrefab;


    // Networking Stuff
    private UdpClient udpClient;
    private IPEndPoint serverEndPoint;
    private Thread receiveThread;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
