using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour 
{
	public int speed = 10;
	void Start()
	{
		//transform.rotation = new Quaternion (0f, 0.7059872f, 0.7082247f, 0f);
		//transform.Rotate (90f, 0f, 0f, Space.World);
	}
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		Destroy (gameObject, 3);
	}

	void OnCollisionEnter(Collider other)
	{
		Debug.Log (other.name);
		if(other.tag == "room"){
			Destroy(gameObject);
		}
	}
}
