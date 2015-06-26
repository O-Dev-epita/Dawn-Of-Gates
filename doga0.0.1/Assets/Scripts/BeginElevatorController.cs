using UnityEngine;
using System.Collections;

public class BeginElevatorController : ElevatorController {


	void Start ()
	{
		Invoke ("openDoors", 2);
	}
	
	void OnTriggerExit()
	{
		Invoke ("closeDoors", 2);
	}
}
