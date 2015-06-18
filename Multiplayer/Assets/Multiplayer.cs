using UnityEngine;
using System.Collections;

public class Multiplayer : MonoBehaviour {

	bool connected;
	double starttime;

	// Use this for initialization
	void Start () {
		connected = false;
		Network.Connect("127.0.0.1", 80);
		starttime = Network.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(connected == false && Network.time > starttime + 4.0)
		{
			Network.Disconnect();
			MasterServer.UnregisterHost();
			Debug.Log("An error happend while trying to connect as client, starting server now");


			Network.InitializeServer(2, 80, false);
		}
	}

	void OnConnectedToServer() {
		connected = true;
		Debug.Log("Successfully onnected to server");
	}
}
