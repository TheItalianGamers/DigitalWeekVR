using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSocketInitializer : MonoBehaviour
{
    public GameObject webSocketServer;

    void Awake()
    {

        if (WebSocketManager.Instance == null)
            Instantiate(webSocketServer);

    }

}
