using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 0.3f;

	void Start()
	{


	}
	void Update () {

		/*Quaternion targetPos = Quaternion.LookRotation (ninja.transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetPos, Time.deltaTime * 5);
		*/
		//Destroy (gameObject, 4);
		//Vector3 relativePos = ninja.transform.position - transform.position;

		transform.Translate(Vector3.forward * Time.deltaTime * speed);



	}


}
