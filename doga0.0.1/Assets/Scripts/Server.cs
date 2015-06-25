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

	private TriggerStruct triggers;

	static int nbMessages = 0;

	public Transform persoTransform;

	public GameObject waitMenu;
	public GameObject theGame;

	public GameObject leftPortal;
	public GameObject rightPortal;

	public GameObject[] enemiesObjects;

	public GameObject canvasWin;
	public GameObject canvasLost;

	private bool clientConnected;

	private PersoStruct perso;
	private EnnemyStruct[] enemies;

	public const byte NINJA_DIE = 24;
	public const byte NINJA_WIN = 25;

	private PortalStruct lp;
	private PortalStruct rp;

	private Thread thread;

	private bool sendEnnemy;
	private bool gameEnded;
	private bool isWinner;

	private BinaryWriter bw;
	private BinaryReader br;

	
	void Start () 
	{

		gameEnded = false;
		isWinner = false;

		enemies = new EnnemyStruct[enemiesObjects.Length];

		enemyIndex = 0;

		clientConnected = false;

		triggers = new TriggerStruct (42);

		listener = new TcpListener(PORT);
		IPEndPoint ip =  (IPEndPoint) listener.LocalEndpoint;
		listener.Start();
		Debug.Log("Server mounted, listening to  port " + PORT);
		thread = new Thread(new ThreadStart(Service));
		thread.Start();
	}

	public void spawnEnnemy(Vector3 pos)
	{
		if (enemyIndex != enemiesObjects.Length)
		{
			enemiesObjects[enemyIndex].transform.position = pos;
			enemiesObjects[enemyIndex].SetActive(true);
			EnnemyStruct ennemySpawn = new EnnemyStruct(enemiesObjects[enemyIndex].transform, enemyIndex);
			enemies[enemyIndex] = ennemySpawn;
			bw.Write(ennemySpawn.tobyte());
			enemyIndex++;
		}
	}

	public void Update()
	{

		if(gameEnded)
		{
			if(isWinner)
			{
				canvasWin.SetActive(true);
			}
			else
			{
				canvasLost.SetActive(true);
			}
		}

		if (clientConnected) 
		{
			waitMenu.SetActive (false);
			theGame.SetActive(true);
			persoTransform.position = perso.pos;
			persoTransform.rotation = perso.rot;

			for(int i = 0; i < enemyIndex; i++)
			{
				enemiesObjects[i].transform.position = enemies[i].pos;
				enemiesObjects[i].transform.rotation = enemies[i].rot;
			}


			if( (leftPortal.transform.position != lp.pos || !GameState.Instance.leftPortalOpen) && lp.opened)
			{
				leftPortal.GetComponent<Teleportation>().animatedportal.animation.Play();
			}
			leftPortal.transform.position = lp.pos;
			leftPortal.transform.rotation = lp.rot;
			GameState.Instance.leftPortalOpen = lp.opened;


			if( ( rightPortal.transform.position != rp.pos || !GameState.Instance.rightPortalOpen) && rp.opened)
			{
				rightPortal.GetComponent<Teleportation>().animatedportal.animation.Play();
			}
			rightPortal.transform.position = rp.pos;
			rightPortal.transform.rotation = rp.rot;
			GameState.Instance.rightPortalOpen = rp.opened;
			
			//bw.Write(triggers.tobyte());


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
				br = new BinaryReader(s);
				bw = new BinaryWriter(s);
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
					else if(type == PortalStruct.TYPE_LEFT)
					{
						byte[] data = new byte[PortalStruct.SIZE];
						br.Read(data, 0, PortalStruct.SIZE);
						lp = new PortalStruct(data);
					}
					else if(type == PortalStruct.TYPE_RIGHT)
					{
						byte[] data = new byte[PortalStruct.SIZE];
						br.Read(data, 0, PortalStruct.SIZE);
						rp = new PortalStruct(data);
					}

					else if(type == NINJA_WIN)
					{
						gameEnded = true;
						isWinner = false;
						endScene();
					}

					else if(type == NINJA_DIE)
					{
						gameEnded = true;
						isWinner = true;
						endScene();
					}


					else
					{
						Debug.Log("Something wrong happened");
					}

					if(!clientConnected)
					{
						decoUser();
					}
					clientConnected = true;


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

	void OnApplicationQuit()
	{
		endScene ();
	}

	private void decoUser()
	{
		PostRequest req = new PostRequest("members/removeuser.php");
		req.addData ("pseudo", GameState.pseudo);
		req.send ();
	}
	
	private void endScene()
	{
		if(!clientConnected)
		{
			decoUser();
		}
			
		thread.Abort ();
		listener.Stop ();

	}


}