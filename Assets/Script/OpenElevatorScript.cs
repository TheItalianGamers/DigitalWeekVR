using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;

public class OpenElevatorScript : MonoBehaviour
{

    public bool openByDefault = true;

    public Animator elevatorAnimator;
    public BoxCollider elevatorCollider;

    public AudioSource dingAudio;

    private XRBaseInteractable interactable;

    void Start()
    {

       if( !openByDefault ) {
       
          interactable = GetComponent<XRBaseInteractable>();
          interactable.selectEntered.AddListener(Open);

       } else {

	  OpenElevator();

       }

        
    }

    public void Open( BaseInteractionEventArgs args ) {

	if( args.interactorObject is XRPokeInteractor ) OpenElevator();

	interactable.selectEntered.RemoveListener(Open);

    }

    public void AnimateOpening() {

       elevatorAnimator.SetBool("LeftOpened", true);
       elevatorAnimator.SetBool("RightOpened", true);

    }

    public void OpenElevator() {

       AnimateOpening();
       elevatorCollider.enabled = false;

       if( dingAudio.clip != null ) dingAudio.Play();

    }


}
