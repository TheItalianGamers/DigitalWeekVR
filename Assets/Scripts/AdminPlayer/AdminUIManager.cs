using System;
using UnityEngine;

public class AdminUIManager : MonoBehaviour
{
    public GameObject adminUI;
    public GameObject adminUIButtons;
    public GameObject adminUIAdminPanel;
    
    private AdminMovements adminMovements;
    
    public static AdminUIManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        adminMovements = AdminMovements.instance;
    }
    
    public void ToggleAdminUIButtons()
    {
        adminUIButtons.SetActive(!adminUIButtons.activeSelf);
        adminMovements.enabled = !adminMovements.enabled;
        if(!adminUIButtons.activeSelf) adminUIAdminPanel.SetActive(false);
    }
    
    public void toggleAdminUIAdminPanel()
    {
        adminUIAdminPanel.SetActive(!adminUIAdminPanel.activeSelf);
    }
}
