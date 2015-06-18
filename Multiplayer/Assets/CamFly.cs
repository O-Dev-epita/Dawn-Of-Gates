using UnityEngine;
using System.Collections;

public class CamFly : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.mousePosition.x < Screen.width * 0.2)
		{
			transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
		}

		if (Input.mousePosition.x > Screen.width * 0.8)
		{
			transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
		}

		if (Input.mousePosition.y < Screen.height * 0.2)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z  - 0.1f);
		}

		if (Input.mousePosition.y > Screen.height * 0.8)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
		}
	
	}
}
