using UnityEngine;

public class DropPlayerBall : MonoBehaviour {
	
	[SerializeField] public OVRPlayerController player;
	[SerializeField] public OVRGrabber hand;
	private Rigidbody ballRb;

	private void Start() {
		// ballRb = ball.GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == player.tag) {
			Debug.Log(other.gameObject.name);
			// ball.isGrabbed = false;
			// 	rb.velocity = linearVelocity;
        	// rb.angularVelocity = angularVelocity;
			hand.gameObject.SetActive(false);//.GrabEnd(ballRb.velocity, ballRb.velocity);
			hand.gameObject.SetActive(true);
		}
	}
}
