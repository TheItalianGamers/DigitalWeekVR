using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class SpawnHere : MonoBehaviour
{
    public Transform spawnPoint;

    void Awake() {
        XROrigin origin = FindObjectOfType<XROrigin>();

        if(origin) {
            origin.gameObject.transform.position = spawnPoint.position;
            origin.gameObject.transform.rotation = spawnPoint.rotation;
        }
        else
            Debug.Log("XROrigin not found!");

    }
    
}
