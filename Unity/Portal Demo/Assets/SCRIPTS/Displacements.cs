using UnityEngine;
using System.Collections;

public class Displacements : MonoBehaviour {

	public float sensivity;
	public Transform camtransf;

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
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}

		if(Input.GetKey(Keys.Forward))
		{
			transform.position += Vector3.Scale (camtransf.TransformDirection ( Vector3.forward * Time.deltaTime * sensivity) , STAYDOWN);
		}
		if(Input.GetKey(Keys.Back))
		{
			transform.position += Vector3.Scale (camtransf.TransformDirection ( Vector3.back * Time.deltaTime * sensivity) , STAYDOWN);
		}
		if(Input.GetKey(Keys.Left))
		{
			transform.position += Vector3.Scale (camtransf.TransformDirection ( Vector3.left * Time.deltaTime * sensivity) , STAYDOWN);
		}
		if(Input.GetKey(Keys.Right))
		{
			transform.position += Vector3.Scale (camtransf.TransformDirection ( Vector3.right * Time.deltaTime * sensivity) , STAYDOWN);
		}
	
	}
}
