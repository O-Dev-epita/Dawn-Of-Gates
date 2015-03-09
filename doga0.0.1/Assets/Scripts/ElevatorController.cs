using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour {

	public GameObject leftDoor;
	public GameObject rightDoor;
	
	void OnTriggerEnter(Collider other)
	{
		leftDoor.animation.Play ("porteg");
		rightDoor.animation.Play ("ported");
	}

	void OnTriggerExit(Collider other)
	{
		leftDoor.animation.Play ("invporteg");
		rightDoor.animation.Play ("invported");
	}

	void Update ()
	{
	
	}
}
