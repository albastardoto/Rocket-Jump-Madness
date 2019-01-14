using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class RocketScript : NetworkBehaviour {
	public GameObject Explosion;
	private Rigidbody rb;
	private float speed;
	void Start () {
		rb = transform.GetComponent<Rigidbody> ();
		speed = rb.velocity.magnitude * Time.fixedDeltaTime;
	}
	void FixedUpdate () {
		if (isServer) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.right), out hit, speed, 1 << 0)) {
				CmdSpawnExplosion (hit.point + (this.GetComponent<Rigidbody> ().velocity.normalized * 0.01f));
				Destroy (this.gameObject);
			}
		}
	}

	[Command]
	void CmdSpawnExplosion (Vector3 point) {
		GameObject ExplosionInstance = Instantiate (Explosion, point, Quaternion.identity);
		NetworkServer.Spawn (ExplosionInstance);
	}
}