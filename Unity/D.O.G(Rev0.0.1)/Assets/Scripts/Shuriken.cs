using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour 
{
	public int speed = 10;
	
	public GameObject Portal { get; set; }
	
	private bool hasPortal;
	private float distance;
	private RaycastHit hit;
	
	
	void Start()
	{
		
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 100f))
		{
			hasPortal = hit.collider.transform.root.tag == "room";
			this.hit = hit;
			distance = hit.distance;
		}
		else
		{
			hasPortal = false;
			distance = 100f;
		}
	}
	void Update () {
		float dist = Time.deltaTime * speed * GameState.Instance.UniversalTime;
		distance -= dist;
		transform.Translate(Vector3.forward * dist);
		if(distance < 0)
		{
			if(hasPortal) {
				if(Portal.name == "LeftPortal")
				{
					GameState.Instance.leftPortalOpen = true;
				}
				else
				{
					GameState.Instance.rightPortalOpen = true;
				}
				Portal.transform.position = hit.point;
				Portal.transform.rotation = Quaternion.LookRotation(hit.normal);
			}
			Destroy(gameObject);
		}
	}
}
