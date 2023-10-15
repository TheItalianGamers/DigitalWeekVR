using UnityEngine;
using UnityEngine.SceneManagement;

using WebSocketSharp;
using WebSocketSharp.Server;

[System.Serializable]
public class WebSocketMessage {

  public string Event;
  public string Value;

  public WebSocketMessage(string e, string v) {
	Event = e;
	Value = v;
  }

  public static string CreateJson(string e, string v) {
	return JsonUtility.ToJson(new WebSocketMessage(e,v));
  }

}

public class MyWebSocketBehavior : WebSocketBehavior {

    protected override void OnMessage(MessageEventArgs e) {

        WebSocketMessage messageObject = JsonUtility.FromJson<WebSocketMessage>(e.Data);

        switch(messageObject.Event) {

            case "message": {
                Debug.Log(messageObject.Value);
                break;
            }

            case "action": {
                break;
            }

            case "scene": {
                WebSocketManager.GetSceneChangerInstance().prova(messageObject.Value);
                break;
            }


        }
       
        Send(WebSocketMessage.CreateJson("message","Greetings from the server!!!"));

    }

}    


public class WebSocketManager : MonoBehaviour
{
    private WebSocketServer server;
    private static SceneChanger sceneChangerInstance;
    
    public static SceneChanger GetSceneChangerInstance() {
        return sceneChangerInstance;
    }

    void Start() {

        sceneChangerInstance = gameObject.AddComponent<SceneChanger>();

        server = new WebSocketServer(8085);
        server.AddWebSocketService<MyWebSocketBehavior>("/service", s => {
            s.OriginValidator = val => {return true;};
        });

        server.Start();

        if(server.IsListening) {
            Debug.Log("Server running on port " + server.Port); 
        }

    }

    void OnDestroy() {
        server.Stop();
        Debug.Log("Server aborted!");
    }

}
