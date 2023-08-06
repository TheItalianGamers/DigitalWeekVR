using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationScript : MonoBehaviour
{

    public InputActionProperty leftGripAction;
    public InputActionProperty rightGripAction;
    public InputActionProperty leftTriggerAction;
    public InputActionProperty rightTriggerAction;

    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    void Update()
    {
        leftTeleportation.SetActive(leftGripAction.action.ReadValue<float>() == 0 && leftTriggerAction.action.ReadValue<float>() > 0.1);
        rightTeleportation.SetActive(rightGripAction.action.ReadValue<float>() == 0 && rightTriggerAction.action.ReadValue<float>() > 0.1);
    }
}
