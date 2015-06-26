using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Connection : MonoBehaviour {

	public Text pseudoText;
	public InputField passwordText;
	public GetUsers script;

	public Toggle ninjaToggle;

	public void OnClick() {
		
		string url = "index.php?page=signin";
		
		string user = pseudoText.text;
		string password = passwordText.text;
		
		PostRequest req = new PostRequest(url);
		req.addData("pseudo", user);
		req.addData("pass", password);

		if (ninjaToggle.isOn) 
		{
			req.addData("game", "1");
		}
		else
		{
			req.addData("game", "2");
		}

		if(req.send())
		{
			int id = Convert.ToInt32(req.getResponseBody());
			if(id != -1)
			{
				Debug.Log("Connection succeful : " + id);

				GameState.pseudo = user;

				if(!ninjaToggle.isOn)
				{
					Application.LoadLevel("multimdl");
				}

				script.Init(user);
			}
			else
			{
				Debug.Log("Connection failure");
			}
		}
		else
		{
			Debug.Log("Server error");
		}
		
	}
}
