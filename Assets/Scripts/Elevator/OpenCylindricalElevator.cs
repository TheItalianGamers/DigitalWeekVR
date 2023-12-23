using UnityEngine;

public class OpenCylindricalElevator : MonoBehaviour
{
 
    void Start() {

        // Per ora lo script lo lascio così
        // poi quando sarà finita la stanza dell'eden si farà un unico script per gli ascensori
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().SetBool("isOpened", true);
        GetComponent<AudioSource>().Play();
    }

}
