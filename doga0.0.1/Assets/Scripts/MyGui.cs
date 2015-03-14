using UnityEngine;
using System.Collections;

public class MyGui : MonoBehaviour {
	public Material lifebar_mat;
	public float Life;
	
	void Update()
	{
		if (Life > 1)
		{
			Life = 1;
		}
		
		if (Life < 0)
		{
			Life = 0;
		}
		lifebar_mat.SetColor ("_Life", new Color (1.0f - Life, Life, 0f, 1));
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, 0.05113567f * Life);
	}
}
