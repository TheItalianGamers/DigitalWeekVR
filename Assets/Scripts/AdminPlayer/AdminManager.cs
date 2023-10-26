using System;
using UnityEngine;

public class AdminManager : MonoBehaviour
{
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
}
