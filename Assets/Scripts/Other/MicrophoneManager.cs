using UnityEngine;
using UnityEngine.UI;


public class MicrophoneManager : MonoBehaviour {

    public GameObject rectangular;
    private const string myMic = "Microfono (Realtek High Definition Audio)";

    private AudioSource audioSource;

    void Awake() {

        foreach (var device in Microphone.devices)
        {
            Debug.Log("name: " + device);
        }

    }

    void Update() {


    }

}