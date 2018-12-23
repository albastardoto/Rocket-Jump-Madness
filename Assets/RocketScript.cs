using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {
	public GameObject ExplosionParticles;
	void OnTriggerEnter(Collider col){
		Debug.Log("BOOM");
		 Instantiate(ExplosionParticles,this.transform.position,Quaternion.identity);
		 Destroy(gameObject);
	}
}
