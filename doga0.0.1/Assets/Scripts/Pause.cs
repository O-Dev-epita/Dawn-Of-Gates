using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	GameObject text1;
	
	void Update () {

		if (Input.GetKeyDown ("A")) {
			text1.renderer.enabled = true;
		}
		if (Input.GetKeyDown ("B")) {
			text1.renderer.enabled = false;
		}
		}
}
