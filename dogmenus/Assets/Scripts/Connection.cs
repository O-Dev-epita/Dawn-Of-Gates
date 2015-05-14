using UnityEngine;
using System.Collections;
using System;

public class Connection : MonoBehaviour {

	void Start () {
		
		string url = "http://localhost:8888/dog/index.php?page=signin";
		
		string user = "test";
		string password = "ab";
		
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
