using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AnimateHand : MonoBehaviour
{
    public InputActionProperty gripAction;
    public InputActionProperty triggerAction;

    public Animator animator;
    void Update()
    {
        // Reading grip value
        float gripValue = gripAction.action.ReadValue<float>();
        animator.SetFloat("Grip", gripValue);

        // Reading Trigger value
        float triggerValue = triggerAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);

    }
}
