using UnityEngine;

public class TeleportPlayerHere : MonoBehaviour
{
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("PlayerGameObject");
        var admin = GameObject.FindGameObjectWithTag("AdminGameObject");

        player.transform.SetPositionAndRotation(transform.position, transform.rotation);
        player.transform.localScale = transform.localScale;

        admin.transform.SetPositionAndRotation(transform.position + (Vector3.up * 5), transform.rotation);
        admin.transform.localScale = transform.localScale;
    }


}
