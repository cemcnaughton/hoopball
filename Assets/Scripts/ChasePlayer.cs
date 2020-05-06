using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChasePlayer : MonoBehaviour {
 
	public Transform Player;
	public Rigidbody rb;
	int MoveSpeed = 100;
	int MaxDist = 10;
	int MinDist = 5;

	void Update() {
		transform.LookAt(Player);
		float distance = Vector3.Distance(transform.position, Player.position);
		if (distance >= MinDist) {
			//  transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			rb.AddForce(transform.forward * distance * MoveSpeed * Time.deltaTime);
			if (distance <= MaxDist) {
				// rb.AddForce(transform.forward * distance * MoveSpeed * Time.deltaTime);
			}
		}
	}
}