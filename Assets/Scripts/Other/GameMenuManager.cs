using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Per ora lo script non funziona: ovvero con il simulatore non si riesce a richiamare la menuAction;
// Quindi il canva del menu è attualmente lasciato visibile nella scena.


public class GameMenuManager : MonoBehaviour
{

    public GameObject menu;
    public InputActionProperty menuAction;

    public Transform head;
    public float spawnDistance = 2f;


    void Update()
    {

       if( menuAction.action.WasPressedThisFrame() ) {

         menu.SetActive(!menu.activeSelf);

	 menu.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized * spawnDistance;
	 menu.transform.LookAt( new Vector3(head.position.x, menu.transform.position.y, head.position.z) );
	 menu.transform.forward *= -1;

       }

        
    }
}
