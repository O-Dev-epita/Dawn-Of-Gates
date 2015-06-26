using UnityEngine;
using System.Collections;

public class Displacements : MonoBehaviour {

	public GameObject camera;
	public float sensivity;
	public GameObject camerarot;

	[System.Serializable]
	public class KeyConfig
	{
		public string Forward;
		public string Back;
		public string Left;
		public string Right;
	}

	public KeyConfig Keys;

	Vector3 STAYDOWN = new Vector3(1,0,1);



	void Update () {


		if(Input.GetKey(Keys.Forward))
		{
			transform.position += Vector3.Scale (camerarot.transform.TransformDirection ( Vector3.forward * Time.deltaTime * sensivity) , STAYDOWN);
			transform.rotation = new Quaternion(transform.rotation.x,camerarot.transform.rotation.y,transform.rotation.z,camerarot.transform.rotation.w);
			camera.transform.position = transform.position + new Vector3(0f,0.8f,0f);
		}
		if(Input.GetKey(Keys.Back))
		{
			transform.position += Vector3.Scale (camerarot.transform.TransformDirection ( Vector3.back * Time.deltaTime * sensivity) , STAYDOWN);
			transform.rotation = new Quaternion(transform.rotation.x,camerarot.transform.rotation.y,transform.rotation.z,camerarot.transform.rotation.w);
			camera.transform.position = transform.position + new Vector3(0f,0.8f,0f);
		}
		if(Input.GetKey(Keys.Left))
		{
			transform.position += Vector3.Scale (camerarot.transform.TransformDirection ( Vector3.left * Time.deltaTime * sensivity) , STAYDOWN);
			transform.rotation = new Quaternion(transform.rotation.x,camerarot.transform.rotation.y,transform.rotation.z,camerarot.transform.rotation.w);
			camera.transform.position = transform.position + new Vector3(0f,0.8f,0f);
		}
		if(Input.GetKey(Keys.Right))
		{
			transform.position += Vector3.Scale (camerarot.transform.TransformDirection ( Vector3.right * Time.deltaTime * sensivity) , STAYDOWN);
			transform.rotation = new Quaternion(transform.rotation.x,camerarot.transform.rotation.y,transform.rotation.z,camerarot.transform.rotation.w);
			camera.transform.position = transform.position + new Vector3(0f,0.8f,0f);
		}
	
	}
}
