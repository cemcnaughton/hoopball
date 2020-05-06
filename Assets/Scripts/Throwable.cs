using UnityEngine;

public class Throwable : MonoBehaviour {
	
	[SerializeField]
	private float speed = 5.0f;
	[SerializeField]
	private Rigidbody rb;
	[SerializeField]
    public OVRGrabbable grabbable;
	[SerializeField]
	public OVRInput.Controller controller;
	private bool wasGrabbed = true;
	private bool wasReleased = false;
	
	private void Update(){
		if(!wasGrabbed){
			wasGrabbed = CheckIfGrabbed();
		}
		else if(CheckIfReleased()){
			Throw();
		}
	}

	private bool CheckIfGrabbed(){
        if(grabbable && grabbable.isGrabbed) {
			wasReleased = false;
			return true;
		}
		return false;
	}

	private bool CheckIfReleased(){
        if(grabbable && !grabbable.isGrabbed) {
			wasReleased = true;
			wasGrabbed = false;
		}

		return wasReleased;
	}

	private void Throw(){
		// rb.rotation = OVRInput.GetLocalControllerRotation(controller);
		rb.velocity = rb.velocity * speed;
	}

}

