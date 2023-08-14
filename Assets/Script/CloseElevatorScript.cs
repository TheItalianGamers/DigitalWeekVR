using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CloseElevatorScript : MonoBehaviour
{

    public Animator elevatorAnimator;
    public BoxCollider elevatorCollider;

    public string sceneToGo;

    private SceneChanger sceneChanger;

    void Start()
    {
       sceneChanger = GetComponent<SceneChanger>();

       XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
       interactable.selectEntered.AddListener(Close);
    }

    public void AnimateClosing() {

       elevatorAnimator.SetBool("LeftOpened", false);
       elevatorAnimator.SetBool("RightOpened", false);

    }
    

    public void Close( BaseInteractionEventArgs args ) {

        if( args.interactorObject is XRPokeInteractor ) {

	   AnimateClosing();
	   elevatorCollider.enabled = true; 
	   sceneChanger.changeScene(sceneToGo);

	}

    }



}
