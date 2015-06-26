using UnityEngine;
using System.Collections;

public class ThrowShuriken : MonoBehaviour {

	public GameObject leftPortal;
	public GameObject rightPortal;
	public GameObject shu;
	public GameObject shus;

	// Use this for initialization
	void Start () {
	
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
		{
			GameObject portal = Input.GetButtonDown("Fire1") ? leftPortal : rightPortal;
			GameObject shuClone = (GameObject) Instantiate(shu,shus.transform.position,shus.transform.rotation);
			shuClone.GetComponent<Shuriken>().Portal = portal;
		}
	}
	
}
