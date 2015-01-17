using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour {

	public GameObject otherportal;
	public GameObject maincam;

	void OnTriggerEnter(Collider other)
	{
		other.transform.position = otherportal.transform.position;
		maincam.transform.rotation = otherportal.transform.rotation;
		other.transform.position += maincam.transform.TransformDirection (Vector3.forward * 1.2f);
	}
}
