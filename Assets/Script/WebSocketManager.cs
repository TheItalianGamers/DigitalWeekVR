using UnityEngine;
using UnityEngine.SceneManagement;

using WebSocketSharp;
using WebSocketSharp.Server;

using System;
using System.Collections.Concurrent;

[Serializable]
public static class WebSocketEvent
{

    // Sending Events
    public static readonly string OnUnityExited = "unity-exited";

    // Receiving Events
    public static readonly string OnChangeScene = "change-scene";
    public static readonly string OnSetDifficultyLevel = "set-difficulty-level";

    // Sending/Receiving Events
    public static readonly string OnMessage = "message";

}

[Serializable]
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

    // Delegates and Events:
    public delegate void SceneDelegate(string sceneName);
    public event SceneDelegate OnSceneEvent;

    public delegate void DifficultyDelegate(string difficultyMode);
    public event DifficultyDelegate OnSetDifficultyMode;

    // -------------------------------------------

    protected override void OnOpen()
    {
        WebSocketManager.Instance.OnEmitToClient += WebSocketManager_OnEmitToClient;
    }

    protected override void OnMessage(MessageEventArgs e)
    {

        WebSocketMessage messageObject = JsonUtility.FromJson<WebSocketMessage>(e.Data);

        if (messageObject.Event == WebSocketEvent.OnMessage)
        {
            Debug.Log(messageObject.Value);
            WebSocketManager_OnEmitToClient(WebSocketEvent.OnMessage, "The server received the message correctly");
            return;
        }

        if (messageObject.Event == WebSocketEvent.OnChangeScene)
        {
            OnSceneEvent?.Invoke(messageObject.Value);
            return;
        }

        if (messageObject.Event == WebSocketEvent.OnSetDifficultyLevel)
        {
            OnSetDifficultyMode?.Invoke(messageObject.Value);
            return;
        }

    }

    private void WebSocketManager_OnEmitToClient(string e, string v)
    {
        string jsonString = WebSocketMessage.CreateJson(e, v);
        Send(jsonString);
    }

}


public class WebSocketManager : MonoBehaviour
{
    private WebSocketServer server;
    private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();

    public delegate void EmitDelegate(string Event, string Value);
    public event EmitDelegate OnEmitToClient;

    public static WebSocketManager Instance;

    private GlobalSettingsManager globalSettingsManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        globalSettingsManager = this.gameObject.GetComponent<GlobalSettingsManager>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        server = new WebSocketServer(8085);
        server.AddWebSocketService<MyWebSocketBehavior>("/service", s =>
        {
            s.OriginValidator = val => { return true; };
            s.OnSceneEvent += MyWebSocketBehavior_OnSceneEvent;
            s.OnSetDifficultyMode += MyWebSocketBehavior_OnSetDifficultyMode;
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
        Instance = null;
        OnEmitToClient?.Invoke(WebSocketEvent.OnUnityExited, "");
        server.Stop();
    }

    private void MyWebSocketBehavior_OnSceneEvent(string sceneName)
    {
        // Dispatch into the Unity main thread's next Update routine
        _actions.Enqueue(() =>
        {
            if (sceneName != SceneManager.GetActiveScene().name)
            {
                SceneManager.LoadScene(sceneName);
                OnEmitToClient?.Invoke(WebSocketEvent.OnMessage, "The scene has been changed correctly!");
            }
            else
            {
                OnEmitToClient?.Invoke(WebSocketEvent.OnMessage, $"The user is still in the {sceneName}!");
            }
        });

    }

    private void MyWebSocketBehavior_OnSetDifficultyMode(string difficultyMode)
    {
        // Dispatch into the Unity main thread's next Update routine
        _actions.Enqueue(() =>
        {
            if (GlobalSettings.LevelOfDifficulty != difficultyMode)
            {
                globalSettingsManager.SetDifficultyMode(difficultyMode);
                OnEmitToClient?.Invoke(WebSocketEvent.OnMessage, $"Now the mode is set to {GlobalSettings.LevelOfDifficulty}!");
            }
            else
            {
                OnEmitToClient?.Invoke(WebSocketEvent.OnMessage, $"The mode is still set to {difficultyMode}");
            }
        });
    }

}
