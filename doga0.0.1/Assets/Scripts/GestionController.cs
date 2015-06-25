using UnityEngine;
using System.Collections;

public class GestionController : MonoBehaviour {

	
	void Start () {
	
		if(PlayerPrefs.HasKey("account_id") && PlayerPrefs.GetInt("account_id") != -1)
		{
			Application.LoadLevel("manager");
		}
		else
		{
			Application.LoadLevel("connection");
		}
	
	}
}
