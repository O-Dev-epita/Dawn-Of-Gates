using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour {
	
	public GameObject otherPortal;
	public Texture openedPortalTexture;
	public Texture closedPortalTexture;
	public GameObject animatedportal;

	
	// Use this for initialization
	void Start () {
	
	}
	
	bool teleportOk() {
		GameState gameState = GameState.Instance;
		return gameState.leftPortalOpen && gameState.rightPortalOpen;
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTexture = teleportOk() ? openedPortalTexture : closedPortalTexture;
	}
	
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log(collider.name);
		if(this.teleportOk())
		{
			collider.transform.position = otherPortal.transform.position;
			Camera.main.transform.rotation = otherPortal.transform.rotation;
			collider.transform.position += Camera.main.transform.TransformDirection(Vector3.forward * 2f);
			//collider.transform.rotation = otherPortal.transform.rotation;

		}	
	}


}
