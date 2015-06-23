using UnityEngine;
using System.Collections;
using System;

public class ElevatorController : MonoBehaviour {

	public GameObject leftDoor;
	public GameObject rightDoor;
	public int level;

	public void closeDoors()
	{
		leftDoor.animation.Play("porteg");
		rightDoor.animation.Play("ported");
	}

	public void openDoors()
	{
		leftDoor.animation.Play("invporteg");
		rightDoor.animation.Play("invported");
	}

	public void nextLevel()
	{
		Application.LoadLevel(level+1);
	}
}
