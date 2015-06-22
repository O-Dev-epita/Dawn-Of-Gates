using UnityEngine;
using System.Collections;

public class Multiplayer : MonoBehaviour {

	bool connected;
	bool tryserver;
	double starttime;

	// Use this for initialization
	void Start () {
		connected = false;
		Network.Connect("127.0.0.1", 25000);
		starttime = Network.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(connected == false && Network.time > starttime + 4.0 && tryserver == false)
		{
			Network.Disconnect();
			MasterServer.UnregisterHost();
			Debug.Log("An error happend while trying to connect as client, starting server now");


			Network.InitializeServer(5, 25000, false);
			tryserver = true;
		}
	}

	void OnConnectedToServer() {
		connected = true;
		Debug.Log("Successfully onnected to server");
	}

	void OnServerInitialized() {
		Debug.Log("Server initialized");
	}
}
