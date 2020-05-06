using UnityEngine;

public class GoalScript : MonoBehaviour {
	
	[SerializeField] ScoreScript scoreScript;
	
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "ball"){
			Debug.Log("Goal !!!!!");
			scoreScript.AddNewScore();
		}
	}
}
