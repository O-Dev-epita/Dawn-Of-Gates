using UnityEngine;
using System.Collections;

public class MyGui : MonoBehaviour {
	public Texture outline;
	public Texture lifebar;
	public Material outline_mat;
	public Material lifebar_mat;
	public float Life;

	void OnGUI()
	{
		if (Life > 1)
		{
			Life = 1;
		}
		Graphics.DrawTexture (new Rect(10, 10, 493, 76), outline, outline_mat);
		lifebar_mat.SetColor ("_Life", new Color (1.0f - Life, Life, 0f, 1));
		Graphics.DrawTexture (new Rect(21, 22, 470 * Life, 50), lifebar, lifebar_mat);
	}
}
