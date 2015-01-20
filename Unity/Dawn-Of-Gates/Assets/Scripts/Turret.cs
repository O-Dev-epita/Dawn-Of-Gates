using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public Rigidbody bulletPrefab;
	private Transform target;
	public Projectile bullet;
	private float nextFire;

	
	void OnTriggerEnter(Collider otherCollider) {

			target = otherCollider.transform;
			StartCoroutine ("Fire");
		
	}
	
	void  OnTriggerExit(Collider otherCollider) {

			target = null;
			StopCoroutine("Fire");

	}
	
	IEnumerator Fire()
	{
		while (target != null)
		{
			nextFire = Time.time + 0.5f;
			while (Time.time < nextFire)
			{


				yield return new WaitForEndOfFrame();
			}


			bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as Projectile;

		}
	}

}
