using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject portal1;
	public GameObject portal2;
	public GameObject MainCamera;

	void Start() {
		Screen.showCursor = false;
		}

	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			throwPortal(portal1);
		}
		if (Input.GetMouseButtonDown (1)) 
		{
			throwPortal (portal2);
		}
	}
	
	void throwPortal(GameObject portal) {
		Ray ray = MainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {
			Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
			portal.transform.position = hit.point;
			portal.transform.rotation = hitObjectRotation;
		}
	}
}