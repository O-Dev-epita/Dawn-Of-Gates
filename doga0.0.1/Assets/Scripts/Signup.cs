using UnityEngine;
using System.Collections;

public class Signup : MonoBehaviour {


	void Start () {
	
		string url = "http://localhost:8888/dog/index.php?page=signup";
		
		string user = "test45";
		string pass1 = "lol";
		string pass2 = pass1;
		
		PostRequest req = new PostRequest(url);
		req.addData("pseudo", user);
		req.addData("pass1", pass1);
		req.addData("pass2", pass2);
		req.addData("game", "1");
		if(req.send())
		{
			string res = req.getResponseBody();
			if(res == "Ok")
			{
				Debug.Log("Signup succeful");
			}
			else
			{
				Debug.Log("Signup error : " + res);
			}
		}
		else
		{
			Debug.Log("Server error");
		}
			
	
	}
}
