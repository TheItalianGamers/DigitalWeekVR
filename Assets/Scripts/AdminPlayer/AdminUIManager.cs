using System;
using UnityEngine;

public class AdminUIManager : MonoBehaviour
{
    public GameObject adminUI;
    public GameObject adminUIButtons;
    public GameObject adminUIAdminPanel;
    public GameObject adminUISceneChanger;
    
    private AdminMovements adminMovements;
    private AdminManager adminManager;
    
    public static AdminUIManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        adminMovements = AdminMovements.instance;
        adminManager = AdminManager.instance;
    }
    
    public void ToggleAdminUIButtons()
    {
        adminUIButtons.SetActive(!adminUIButtons.activeSelf);
        adminUIAdminPanel.SetActive(false);
        adminUISceneChanger.SetActive(false);
        adminMovements.enabled = !adminUIButtons.activeSelf;
    }
    
    public void OnClickToggleAdminUIAdminPanel()
    {
        adminUIAdminPanel.SetActive(!adminUIAdminPanel.activeSelf);
        adminUIButtons.SetActive(!adminUIAdminPanel.activeSelf);
        if(!adminUIAdminPanel.activeSelf) adminUIAdminPanel.SetActive(false);
    }

    public void OnClickToggleSceneChanger()
    {
        adminUISceneChanger.SetActive(!adminUISceneChanger.activeSelf);
    }
    
    public void OnClickToggleXRSimulator()
    {
        adminManager.ToggleXRSimulator();
    }

    public void OnClickChangeScene(string scene)
    {
        adminManager.ChangeScene(scene);
    }
    
    public void OnClickToggleAdminVisibility()
    {
        adminManager.ToggleAdminVisibility();
    }
    
    public void OnClickTeleportAdminToPlayer()
    {
        adminManager.TeleportAdminToPlayer();
    }
    
    public void OnClickTeleportPlayerToAdmin()
    {
        adminManager.TeleportPlayerToAdmin();
    }

    public void OnClickChangeCamera() 
    {
        adminManager.ChangeCamera();
    }

    public void OnClickToggleInstructionsUI()
    {
        adminManager.ToggleInstructionsUI();
    }

}
