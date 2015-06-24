using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Connection : MonoBehaviour {

	public Text pseudoText;
	public Text passwordText;
	public GetUsers script;

	public void OnClick() {
		
		string url = "index.php?page=signin";
		
		string user = pseudoText.text;
		string password = passwordText.text;
		
		PostRequest req = new PostRequest(url);
		req.addData("pseudo", user);
		req.addData("pass", password);
		req.addData("game", "1");
		if(req.send())
		{
			int id = Convert.ToInt32(req.getResponseBody());
			if(id != -1)
			{
				Debug.Log("Connection succeful : " + id);
				script.Init(user);
				GameState.pseudo = user;
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
