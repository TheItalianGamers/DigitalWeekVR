using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    public GameObject welcomeSlide;
    public GameObject scenesSlide;

    private CapsuleCollider lightBeamCollider;
    void Start()
    {
        lightBeamCollider = GetComponentInChildren<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }
}
