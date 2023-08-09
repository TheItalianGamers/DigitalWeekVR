using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationScript : MonoBehaviour
{ 

    public InputActionProperty leftGripAction;


    public InputActionProperty rightGripAction;
    public InputActionProperty leftTriggerAction;
    public InputActionProperty rightTriggerAction;

    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public XRRayInteractor leftRay;
    public XRRayInteractor rightRay;


    void Update()
    {
	bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);

        leftTeleportation.SetActive( !isLeftRayHovering && leftGripAction.action.ReadValue<float>() == 0 && leftTriggerAction.action.ReadValue<float>() > 0.1);

	bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        rightTeleportation.SetActive( !isRightRayHovering && rightGripAction.action.ReadValue<float>() == 0 && rightTriggerAction.action.ReadValue<float>() > 0.1);
    }
}
