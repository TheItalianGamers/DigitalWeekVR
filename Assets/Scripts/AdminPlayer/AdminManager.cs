using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminManager : MonoBehaviour
{
    public GameObject simulatorXR;
    
    private AdminUIManager adminUIManager;
    private AdminMovements adminMovements;
    
    public static AdminManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        adminUIManager = AdminUIManager.instance;
        adminMovements = AdminMovements.instance;
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
        SceneManager.LoadScene(scene);
    }
}
