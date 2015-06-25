using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.IO;
using System.Net.Sockets;

public class Multi : MonoBehaviour {

	TcpClient client;
	const int PORT = 2055;

	private int ennemyIndex;

	public GameObject[] enemiesObjects;

	private TriggerStruct triggers;

	private EnnemyStruct[] enemies;

	private EnnemyStruct spawnEnemy;
	private bool isSpawnEnemy;

	public GameObject leftPortal;
	public GameObject rightPortal;

	public Transform cube;

	Stream s;
	BinaryWriter bw;
	BinaryReader br;

	PersoStruct perso;

	void Start()
	{

		isSpawnEnemy = false;

		ennemyIndex = 0;
		enemies = new EnnemyStruct[enemiesObjects.Length];
		triggers = new TriggerStruct (42);

		client = new TcpClient(GameState.serverAdress, PORT);
		Service();
		Thread thread = new Thread (updateMessages);
		thread.Start ();
	}

	void updateMessages()
	{
		while(true)
		{

			byte type = br.ReadByte();

			if(type == EnnemyStruct.TYPE)
			{
				byte[] data = new byte[EnnemyStruct.SIZE];
				br.Read(data, 0, EnnemyStruct.SIZE);

				spawnEnemy = new EnnemyStruct(data);
				isSpawnEnemy = true;
				Debug.Log("received ennemy");
			}

			else if(type == TriggerStruct.TYPE)
			{
				byte[] data = new byte[TriggerStruct.SIZE];
				br.Read(data, 0, TriggerStruct.SIZE);
				triggers = new TriggerStruct(data);
			}

		}
	}

	void Update()
	{

		if(isSpawnEnemy)
		{
			enemies[ennemyIndex] = spawnEnemy;
			enemiesObjects[ennemyIndex].transform.position = spawnEnemy.pos;
			enemiesObjects[ennemyIndex].transform.rotation = spawnEnemy.rot;
			enemiesObjects[ennemyIndex].SetActive(true);
			ennemyIndex++;
			isSpawnEnemy = false;
		}

		perso.pos = cube.transform.position;
		perso.rot = cube.transform.rotation;
		bw.Write(perso.tobyte());

		bw.Write (new PortalStruct (leftPortal.transform, GameState.Instance.leftPortalOpen).tobyte(PortalStruct.TYPE_LEFT));
		bw.Write (new PortalStruct (rightPortal.transform, GameState.Instance.rightPortalOpen).tobyte(PortalStruct.TYPE_RIGHT));

		for(int i = 0; i < ennemyIndex; i++)
		{
			bw.Write( new EnnemyStruct(enemiesObjects[i].transform, i).tobyte());
		}


	}

	void Service()
	{

		s = client.GetStream();
		bw = new BinaryWriter(s);
		br = new BinaryReader(s);

		perso = new PersoStruct();

		Debug.Log("Connected to " + GameState.serverAdress + ":" + PORT);

	}

	void OnApplicationQuit()
	{
		endScene ();
	}
	
	private void endScene()
	{
		bw.Write (Server.NINJA_DIE);	
	}
}
