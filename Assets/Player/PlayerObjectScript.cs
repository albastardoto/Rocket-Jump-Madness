﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObjectScript : NetworkBehaviour {
	private Rigidbody playerRigidBody;
	public float movementForce;
	public float maxMovementSpeed;
	public Vector3 centerOfMass = new Vector3 (0, -0.5f, 0);
	public GameObject RocketPrefab;
	public float RocketSpeed = 20f;
	[SyncVar]
	public float ObjectHealth = 100f;

	[SyncVar]
	public float RocketAngle;
	private GameObject RocketLauncher;
	// Use this for initialization
	void Start () {
		transform.Find ("Health").GetComponent<TextMesh> ().text = ObjectHealth.ToString ();
		if (!isLocalPlayer) {
			return;
		}
		playerRigidBody = GetComponent<Rigidbody> ();
		playerRigidBody.centerOfMass = centerOfMass;
		RocketLauncher = transform.GetChild (0).gameObject;
	}

	[Command]
	public void CmdSpawnRocket (Vector3 spawnPos, Quaternion spawnAngle) {
		Debug.Log ("InsideSpawnRocket");
		GameObject Rocket = Instantiate (RocketPrefab, spawnPos, spawnAngle);
		Rocket.GetComponent<Rigidbody> ().velocity = RocketSpeed * Rocket.GetComponent<Transform> ().right;
		NetworkServer.Spawn (Rocket);
	}

	[ClientRpc]
	void RpcChangeHealth (float changeAmount) {
		ObjectHealth += changeAmount;
	}
}