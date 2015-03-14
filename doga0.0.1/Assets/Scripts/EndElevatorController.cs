using UnityEngine;
using System.Collections;

public class EndElevatorController : ElevatorController {

	void OnTriggerEnter(Collider other)
	{
		closeDoors ();
		Invoke ("nextLevel", 2);
	}
}
