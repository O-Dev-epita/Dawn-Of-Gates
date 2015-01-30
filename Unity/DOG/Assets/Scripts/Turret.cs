using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public Rigidbody bulletPrefab;
	private Transform target;
	public Projectile bullet;
	private float nextFire;
	private turretspawn scr;

	void Start()
	{
		GameObject spawn = GameObject.FindWithTag ("turretspawn");
		scr = (turretspawn) spawn.GetComponent(typeof(turretspawn));
	}
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

			bullet = Instantiate(bulletPrefab, scr.getTr().position, scr.getTr().rotation) as Projectile;

		}
	}

}
