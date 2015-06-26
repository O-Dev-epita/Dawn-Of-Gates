using UnityEngine;
using System.Collections;

public class UIMnager : MonoBehaviour {

	public Server serverScript;

	public void Activate()
	{
		StartCoroutine ("Spawn");
	}

	IEnumerator Spawn()
	{
		while (true)
		{
			if(Input.GetButton("Fire1"))
			{
				spawnEnnemy(Input.mousePosition.x, Input.mousePosition.y);
			}
			yield return null;
		}
	}

	private void spawnEnnemy(float x, float y)
	{
		StopCoroutine ("Spawn");
		Vector3 mousePos = new Vector3(x, y, 64.5f);
		Vector3 pos = Camera.main.ScreenToWorldPoint (mousePos);
		serverScript.spawnEnnemy (pos);
	}
}
