using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateMovementsTurnScript : MonoBehaviour
{

    private ActionBasedContinuousMoveProvider moveProvider;
    private ActionBasedSnapTurnProvider turnProvider;

    private float originalMoveSpeed;
    private float originalTurnAmount;

    void Awake() {
        moveProvider = GetComponent<ActionBasedContinuousMoveProvider>();
        turnProvider = GetComponent<ActionBasedSnapTurnProvider>();
        originalMoveSpeed = moveProvider.moveSpeed;
        originalTurnAmount = turnProvider.turnAmount;
    }

    public void EnableMovementAction() {
        moveProvider.moveSpeed = originalMoveSpeed;
        Debug.Log("Enabled movements!");
    }

    public void EnableTurnAction() {
        turnProvider.turnAmount = originalTurnAmount;
        Debug.Log("Enabled turn!");
    }

    public void DisableMovementAction() {
        moveProvider.moveSpeed = 0f;
        Debug.Log("Disabled movements!");
    }

    public void DisableTurnAction() {
        turnProvider.turnAmount = 0f;
        Debug.Log("Disabled turn!");
    }
 
    
}
