using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminManager : MonoBehaviour
{
    public GameObject simulatorXR;
    public GameObject adminPlayerMesh;
    public GameObject adminLaserPointer;
    public GameObject adminPlayer;
    public Camera adminCamera;
    public GameObject player;
    
    private AdminUIManager adminUIManager;
    private AdminMovements adminMovements;
    
    private string currentScene;
    private GameObject currentInstructionsUI;

    public static AdminManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        adminUIManager = AdminUIManager.instance;
        adminMovements = AdminMovements.instance;
        ChangeScene("Tutorial-Room");
    }

    void Update()
    {
        UpdateInputs();
    }

    void UpdateInputs()
    {
        if(Input.GetKeyDown(KeyCode.Q)) adminUIManager.ToggleAdminUIButtons();
    }

    public void ToggleXRSimulator()
    {
        simulatorXR.SetActive(!simulatorXR.activeSelf);
    }

    public void ChangeScene(string scene)
    {
        if(currentScene != null)
            SceneManager.UnloadSceneAsync(currentScene);
        
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        currentScene = scene;
    }

    public void ToggleAdminVisibility()
    {
        adminPlayerMesh.SetActive(!adminPlayerMesh.activeSelf);
        adminLaserPointer.SetActive(!adminLaserPointer.activeSelf);
    }

    public void TeleportAdminToPlayer()
    {
        adminPlayer.transform.position = player.transform.position;
    }
    
    public void TeleportPlayerToAdmin()
    {
        player.transform.position = adminPlayer.transform.position;
    }

    public void ChangeCamera() 
    {
        adminCamera.enabled = !adminCamera.enabled; 
    }

    // Da fixare mettendo la UI nella scena gameplay e cambiare dinamicamente il contenuto testuale ogni volta che si cambia la stanza
    public void ToggleInstructionsUI()
    {
        if (currentInstructionsUI == null) {
            currentInstructionsUI = GameObject.FindGameObjectWithTag("InstructionsUI");
        }

        currentInstructionsUI.SetActive(!currentInstructionsUI.activeSelf);
    }

}
