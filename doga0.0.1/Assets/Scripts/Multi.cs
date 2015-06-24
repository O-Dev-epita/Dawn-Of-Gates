using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.IO;
using System.Net.Sockets;

public class Multi : MonoBehaviour {

	TcpClient client;
	const int PORT = 2055;

	public Transform cube;

	Stream s;
	BinaryWriter bw;
	BinaryReader br;

	data Data;


	struct data
	{
		public Vector3 pos;
		public Quaternion rot;


		public byte[] tobyte()
		{
			byte[] result = new byte[28];
			BitConverter.GetBytes(pos.x).CopyTo(result, 0);
			BitConverter.GetBytes(pos.y).CopyTo(result, 4);
			BitConverter.GetBytes(pos.z).CopyTo(result, 8);
			BitConverter.GetBytes(rot.x).CopyTo(result, 12);
			BitConverter.GetBytes(rot.y).CopyTo(result, 16);
			BitConverter.GetBytes(rot.z).CopyTo(result, 20);
			BitConverter.GetBytes(rot.w).CopyTo(result, 24);
			return result;
		}

		public void tostruct(byte[] received)
		{
			pos.x = BitConverter.ToSingle(received, 0);
			pos.y = BitConverter.ToSingle(received, 4);
			pos.z = BitConverter.ToSingle(received, 8);
			rot.x = BitConverter.ToSingle(received, 12);
			rot.y = BitConverter.ToSingle(received, 16);
			rot.z = BitConverter.ToSingle(received, 20);
			rot.w = BitConverter.ToSingle(received, 24);
		}
	}

	void Start()
	{

		Debug.Log (GameState.serverAdress);

		client = new TcpClient(GameState.serverAdress, PORT);
		Service();
	}

	void Update()
	{
		Data.pos = cube.transform.position;
		Data.rot = cube.transform.rotation;
		bw.Write(Data.tobyte());
		byte[] received = new byte[10];
		br.Read(received, 0, 10);
		UpdateTriggers(received);
	}

	void Service()
	{

		s = client.GetStream();
		bw = new BinaryWriter(s);
		br = new BinaryReader(s);

		Data = new data();
		Data.pos.y = 55.2f;

		Debug.Log("Connected to port " + PORT);

	}

	void UpdateTriggers(byte[] received)
	{

	}
}
