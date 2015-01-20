using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int speed = 2;
	private GameObject ninja;
	void Start()
	{
		ninja = GameObject.FindWithTag ("Player");
	}
	void Update () {

		/*Quaternion targetPos = Quaternion.LookRotation (ninja.transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetPos, Time.deltaTime * 5);
		transform.Translate(Vector3.left * Time.deltaTime * speed);*/
		//Destroy (gameObject, 4);
		//Vector3 relativePos = ninja.transform.position - transform.position;

		transform.LookAt (ninja.transform);


	}


}
