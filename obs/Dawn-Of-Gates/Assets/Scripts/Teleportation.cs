using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour {
	
	public GameObject otherPortal;
	public Texture openedPortalTexture;
	public Texture closedPortalTexture;
	
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
			collider.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 1;
		}	
	}
}
