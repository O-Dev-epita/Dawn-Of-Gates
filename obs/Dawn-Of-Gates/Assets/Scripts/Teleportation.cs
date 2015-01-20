using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour {
	
	public GameObject otherPortal;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log(collider.name);
		//if(collider.tag == "Player")
		//{
			collider.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 1;
		//}	
	}
}
