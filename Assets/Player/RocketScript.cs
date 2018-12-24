using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketScript : MonoBehaviour {
	public float explosionRadius=5f;
	public float explosionForce=10f;
	public GameObject ExplosionParticles;
	private Rigidbody rb;
	private float speed;
	void Start(){
		rb=this.GetComponent<Rigidbody>();
		speed=rb.velocity.magnitude*Time.fixedDeltaTime;
	}
	void FixedUpdate(){	
        // Does the ray intersect any objects excluding the player layer
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, speed, 1<<0))
        {
			
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
		Debug.Log("BOOM");
		 GameObject particles= Instantiate(ExplosionParticles,hit.point,Quaternion.identity);
		 Collider[] colliders = Physics.OverlapSphere(hit.point,explosionRadius,1<<0);
		 foreach(Collider circleHit in colliders)
		 {
			Debug.Log(circleHit);
			if(circleHit.GetComponent<Rigidbody>()!=null){
				circleHit.GetComponent<Rigidbody>().AddExplosionForce(explosionForce,transform.position,explosionRadius,0f,ForceMode.Impulse);
			}
		 }
		 Destroy(particles,.3f);
		 Destroy(gameObject);
        }
		
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
	}
}
