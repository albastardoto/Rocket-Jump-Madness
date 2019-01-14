using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	public float explosionRadius;
	public float explosionForce;
	public float forceDuration = .3f;
	public float effectDuration = .3f;
	private float elapsedTime = 0f;
	void Start () {
		Destroy (this.gameObject, effectDuration);
	}

	// Update is called once per frame
	void FixedUpdate () {
		elapsedTime += Time.fixedDeltaTime;
		if (elapsedTime <= forceDuration) {
			Collider[] colliders = Physics.OverlapSphere (this.transform.position, explosionRadius, 1 << 0);
			foreach (Collider circleHit in colliders) {

				if (circleHit.GetComponent<Rigidbody> () != null) {
					if (circleHit.tag == "Player") {
						Vector3 objectPoint = circleHit.GetComponent<Transform> ().TransformPoint (circleHit.GetComponent<Rigidbody> ().centerOfMass);
						float distance = (objectPoint - this.transform.position).magnitude;
						Vector3 forceDirection = (objectPoint - this.transform.position).normalized;
						circleHit.GetComponent<Rigidbody> ().AddForce (forceDirection * explosionForce * forceMultiplier (distance));
					} else {
						Debug.Log (circleHit);
						Vector3 objectPoint = circleHit.GetComponent<Transform> ().TransformPoint (circleHit.GetComponent<Rigidbody> ().centerOfMass);
						float distance = (objectPoint - this.transform.position).magnitude;
						Vector3 forceDirection = (objectPoint - this.transform.position).normalized;
						circleHit.GetComponent<Rigidbody> ().AddForce (forceDirection * explosionForce * forceMultiplier (distance));
					}
				}
			}
		}
	}
	private float forceMultiplier (float distance) {
		return 1 - (distance / explosionRadius);
	}
}