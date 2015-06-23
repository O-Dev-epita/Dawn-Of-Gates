using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {

	public float sensitivity;
	float rotationY = 0;

	void Update ()
	{
		rotationY += Input.GetAxis("Mouse Y") * sensitivity;
		rotationY = Mathf.Clamp (rotationY, -60, 60);
			
		transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity, 0);
	}
}