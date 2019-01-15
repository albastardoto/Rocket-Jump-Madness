using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketLauncherScript : MonoBehaviour {
	private Transform RocketSpawnPoint;
	public float RocketSpeed = 20f;
	public GameObject RocketPrefab;
	private PlayerObjectScript POScript;
	void Start () {
		RocketSpawnPoint = transform.GetChild (0);
		POScript = transform.GetComponentInParent<PlayerObjectScript> ();
	}
	// Update is called once per frame
	void Update () {
		Debug.Log (POScript);
		if (POScript.hasAuthority) {
			Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			POScript.RocketAngle = angle;
			Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = rotation;
			if (Input.GetButtonDown ("Fire1") && POScript.hasAuthority) {
				POScript.CmdSpawnRocket (RocketSpawnPoint.transform.position, transform.rotation);
			}
		} else {
			float angle = POScript.RocketAngle;
			Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = rotation;
		}
	}

}