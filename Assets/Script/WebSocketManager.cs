using UnityEngine;
using UnityEngine.SceneManagement;

using WebSocketSharp;
using WebSocketSharp.Server;

using System;
using System.Collections.Concurrent;

[System.Serializable]
public class WebSocketMessage
{

    public string Event;
    public string Value;

    public WebSocketMessage(string e, string v)
    {
        Event = e;
        Value = v;
    }

    public static string CreateJson(string e, string v)
    {
        return JsonUtility.ToJson(new WebSocketMessage(e, v));
    }

}

public class MyWebSocketBehavior : WebSocketBehavior
{

    public delegate void SceneDelegate(string sceneName);
    public event SceneDelegate OnSceneEvent;

    protected override void OnOpen()
    {
        WebSocketManager.Instance.OnMessageSend += WebSocketManager_OnMessageSend;
    }

    protected override void OnMessage(MessageEventArgs e)
    {

        WebSocketMessage messageObject = JsonUtility.FromJson<WebSocketMessage>(e.Data);

        switch (messageObject.Event)
        {

            case "message":
                {
                    Debug.Log(messageObject.Value);
                    break;
                }

            case "action":
                {
                    break;
                }

            case "scene":
                {
                    OnSceneEvent?.Invoke(messageObject.Value);
                    break;
                }


        }

        Send(WebSocketMessage.CreateJson("message", "Greetings from the server!!!"));
    }

    private void WebSocketManager_OnMessageSend(string jsonMessage)
    {
        Send(jsonMessage);
    }

}


public class WebSocketManager : MonoBehaviour
{
    private WebSocketServer server;
    private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();

    public delegate void MessageSendDelegate(string jsonMessage);
    public event MessageSendDelegate OnMessageSend;

    public static WebSocketManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        server = new WebSocketServer(8085);
        server.AddWebSocketService<MyWebSocketBehavior>("/service", s =>
        {
            s.OriginValidator = val => { return true; };
            s.OnSceneEvent += MyWebSocketBehavior_OnSceneEvent;
        });

        server.Start();

        if (server.IsListening)
        {
            Debug.Log("Server running on port " + server.Port);
        }

    }

    void Update()
    {

        // Work the dispatched actions on the Unity main thread
        while (_actions.Count > 0)
        {

            if (_actions.TryDequeue(out var action))
            {
                action?.Invoke();
            }

        }

    }

    void OnDestroy()
    {
        OnMessageSend?.Invoke(WebSocketMessage.CreateJson("action", "unity-exit"));
        server.Stop();
    }

    private void MyWebSocketBehavior_OnSceneEvent(string sceneName)
    {
        // Dispatch into the Unity main thread's next Update routine
        _actions.Enqueue(() =>
        {
            if (sceneName != SceneManager.GetActiveScene().name)
                SceneManager.LoadScene(sceneName);
            else
                OnMessageSend?.Invoke(WebSocketMessage.CreateJson("message", $"The user is still in the {sceneName} !"));
        });

    }

}
