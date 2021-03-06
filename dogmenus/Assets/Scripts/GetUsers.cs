﻿using UnityEngine;
using System.Collections;

public class GetUsers : MonoBehaviour {

	string[] usersList;
	public Texture2D background;
	public Texture2D button;
	GUIStyle myStyle;

	public void Init(string user)
	{
		usersList = Connect(user).Split(';');
		myStyle = new GUIStyle();
		myStyle.fontSize = 30;
		myStyle.normal.textColor = new Color(1.0f, 0.5f, 0.0f);

	}

	string Connect (string pseudo) {
		
		string url = "http://localhost/members/getusers.php";
		
		PostRequest req = new PostRequest(url);
		req.addData("pseudo", pseudo);
		req.addData("game", "1");
		if(req.send())
		{
			return req.getResponseBody();
		}
		else
		{
			Debug.Log("Server error");
			return "error";
		}
	
	}

	void OnGUI () {

		if(usersList == null)
		{
			return;
		}

		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

		for(int i=0; i < usersList.Length/2; i++)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 200, 100 + i*121, 400, 111), button);
			GUI.Label (new Rect (Screen.width/2 - 30, 110 + i*121, 100, 20), usersList[i*2], myStyle);
			GUI.Label (new Rect (Screen.width/2 - 70, 160 + i*121, 100, 20), usersList[i*2+1], myStyle);
		}

		if(Input.GetButtonDown("Fire1"))
		{
			for(int i=0; i < usersList.Length/2; i++)
			{
				Rect button = new Rect(Screen.width/2 - 200, 100 + i*121, 400, 111);
				if(button.Contains(Event.current.mousePosition))
				{
					Debug.Log("Boutton " + i + " activé");
				}
			}
		}
	}
}
