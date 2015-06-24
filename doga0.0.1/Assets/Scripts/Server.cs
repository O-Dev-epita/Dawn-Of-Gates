using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Server : MonoBehaviour
{

	TcpListener listener;
	const int PORT = 2055;

	static int nbMessages = 0;

	public Transform persoTransform;
	public GameObject waitMenu;

	private bool clientConnected;

	public PersoStruct perso;

	bool[] triggers;
	
	void Start () 
	{

		clientConnected = false;

		triggers = new bool[10];

		listener = new TcpListener(PORT);
		IPEndPoint ip =  (IPEndPoint) listener.LocalEndpoint;
		listener.Start();
		Debug.Log("Server mounted in " + ip.Address.ToString() + " , listening to  port " + PORT);
		Thread t = new Thread(new ThreadStart(Service));
		t.Start();
	}

	public void Update()
	{
		if (clientConnected) 
		{
			waitMenu.SetActive (false);
			persoTransform.position = perso.pos;
			persoTransform.rotation = perso.rot;
				
		}
		else 
		{
			waitMenu.SetActive(true);
		}
	}

	public void Service()
	{
		while(true)
		{
			Socket soc = listener.AcceptSocket();
			Debug.Log("Connected: " + soc.RemoteEndPoint);
			try
			{
				Stream s = new NetworkStream(soc);
				BinaryReader br = new BinaryReader(s);
				BinaryWriter bw = new BinaryWriter(s);
				while(true)
				{

					byte[] data = new byte[28];
					br.Read(data, 0, 28);

					perso = new PersoStruct();
					perso.tostruct(data);
					clientConnected = true;

					byte[] triggersBytes = new byte[triggers.Length];
					for(int i = 0; i < triggersBytes.Length; i++)
					{
						triggersBytes[i] = triggers[i] ? (byte) 1 : (byte) 0;
					}

					bw.Write(triggersBytes);


				}
				s.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.WriteLine("Disconnected: " + soc.RemoteEndPoint);
			soc.Close();
		}
	}
}