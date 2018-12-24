using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	private Rigidbody playerRigidBody;
	public float movementForce;
	public float maxMovementSpeed;
	private float horizontalInput;
	// Use this for initialization
	void Start () {
		playerRigidBody=GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		horizontalInput = Input.GetAxis("Horizontal") ;
	}
	void FixedUpdate(){
		if(playerRigidBody.velocity.magnitude<=maxMovementSpeed){
			    playerRigidBody.AddForce(new Vector3(horizontalInput,0,0)*movementForce);
		}
	}
}
