using UnityEngine;
using System.Collections;

public class MyGui : MonoBehaviour {
	public Material lifebar_mat;
    public bool lifemana;


    private float life = 1f;
    public float Life
    {
        get { return life; }
        set { 
            life = value;
            if(life < 0)
            {
                life = 0;
            }
            else if(life > 1)
            {
                life = 1;
            }
        }
    }

	
	void Update()
	{
        if (lifemana)
        {
            lifebar_mat.SetColor("_Life", new Color(1.0f - Life, Life, 0f, 1));
        }
        else
        {
            lifebar_mat.SetColor("_Life", new Color(1.0f - Life, 0f, Life, 1));
        }
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, 0.05113567f * Life);

	}
}
