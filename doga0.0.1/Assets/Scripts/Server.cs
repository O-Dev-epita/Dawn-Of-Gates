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

	private int enemyIndex;

	static int nbMessages = 0;

	public Transform persoTransform;

	public GameObject waitMenu;
	public GameObject theGame;

	public GameObject[] enemiesObjects;

	private bool clientConnected;

	private PersoStruct perso;
	private EnnemyStruct[] enemies;

	bool[] triggers;

	private bool sendEnnemy;
	private EnnemyStruct ennemySpawn;

	
	void Start () 
	{

		enemyIndex = 0;
		sendEnnemy = false;

		clientConnected = false;

		triggers = new bool[10];

		listener = new TcpListener(PORT);
		IPEndPoint ip =  (IPEndPoint) listener.LocalEndpoint;
		listener.Start();
		Debug.Log("Server mounted in " + ip.Address.ToString() + " , listening to  port " + PORT);
		Thread t = new Thread(new ThreadStart(Service));
		t.Start();
	}

	public void spawnEnnemy(Transform position)
	{
		if (enemyIndex != enemiesObjects.Length)
		{

			enemiesObjects[enemyIndex].transform.position = position.position;
			enemiesObjects[enemyIndex].transform.rotation = position.rotation;
			enemiesObjects[enemyIndex].SetActive(true);
			ennemySpawn = new EnnemyStruct(position, enemyIndex);
			sendEnnemy = true;
			enemyIndex++;
		}
	}

	public void Update()
	{
		if (clientConnected) 
		{
			waitMenu.SetActive (false);
			theGame.SetActive(true);
			persoTransform.position = perso.pos;
			persoTransform.rotation = perso.rot;
				
		}
		else 
		{
			waitMenu.SetActive(true);
			theGame.SetActive(false);
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

					byte type = br.ReadByte();

					if(type == PersoStruct.TYPE)
					{
						byte[] data = new byte[PersoStruct.SIZE];
						br.Read(data, 0, PersoStruct.SIZE);
						perso = new PersoStruct(data);
					}
					else if(type == EnnemyStruct.TYPE)
					{
						byte[] data = new byte[EnnemyStruct.SIZE];
						br.Read(data, 0, EnnemyStruct.SIZE);
						EnnemyStruct enemy = new EnnemyStruct(data);
						enemies[enemy.index] = enemy;
					}
					else
					{
						Debug.Log("Something wrong happened");
					}

					clientConnected = true;

					if(sendEnnemy)
					{

						bw.Write(ennemySpawn.tobyte());

						sendEnnemy = false;
					}

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