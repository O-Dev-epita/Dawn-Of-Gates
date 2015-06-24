using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.IO;
using System.Net.Sockets;

public class Multi : MonoBehaviour {

	TcpClient client;
	const int PORT = 2055;

	public GameObject[] enemiesObjects;

	public Transform cube;

	Stream s;
	BinaryWriter bw;
	BinaryReader br;

	PersoStruct perso;

	void Start()
	{

		Debug.Log (GameState.serverAdress);

		client = new TcpClient(GameState.serverAdress, PORT);
		Service();
	}

	void Update()
	{
		perso.pos = cube.transform.position;
		perso.rot = cube.transform.rotation;
		bw.Write (PersoStruct.TYPE);
		bw.Write(perso.tobyte());
		byte[] received = new byte[10];
		br.Read(received, 0, 10);
		UpdateTriggers(received);
	}

	void Service()
	{

		s = client.GetStream();
		bw = new BinaryWriter(s);
		br = new BinaryReader(s);

		perso = new PersoStruct();

		Debug.Log("Connected to port " + PORT);

	}

	void UpdateTriggers(byte[] received)
	{

	}
}
