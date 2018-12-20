using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherScript : MonoBehaviour {
	private Transform RocketSpawnPoint;
	public float RocketSpeed=20f;
	public GameObject RocketPrefab;
	void Start(){
		RocketSpawnPoint=transform.GetChild(0);
	}
	// Update is called once per frame
	void Update () {	

		Vector2 direction= Input.mousePosition-Camera.main.WorldToScreenPoint(transform.position);
		float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
		Quaternion rotation=Quaternion.AngleAxis(angle,Vector3.forward);
		transform.rotation=rotation;
		if (Input.GetButtonDown("Fire1")){
            GameObject Rocket = Instantiate(RocketPrefab, 	RocketSpawnPoint.transform.position, transform.rotation);
			Rocket.GetComponent<Rigidbody>().velocity=RocketSpeed*Rocket.GetComponent<Transform>().right;
		}
	}
}
