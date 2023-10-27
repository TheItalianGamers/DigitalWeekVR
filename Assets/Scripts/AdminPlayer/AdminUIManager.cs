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
        adminMovements.enabled = !adminMovements.enabled;
        if(!adminUIButtons.activeSelf) adminUIAdminPanel.SetActive(false);
        if(!adminUIButtons.activeSelf) adminUIAdminPanel.SetActive(false);
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
}
