using System;
using System.Net;
using System.IO;
using UnityEngine;

public class GameState {

	private static GameState instance;

	private const string SAVE_URL = "scores/save.php";

	public static string pseudo = "";
	public static string serverAdress = "";


	public static GameState Instance
	{
		get {
			if(instance == null)
			{
				instance = new GameState();
			}
			return instance;
		}
	}


	public static int getTimestamp()
	{
		return (int) (System.DateTime.UtcNow - new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
	}

	
	private GameState()
	{
		this.leftPortalOpen = false;
		this.rightPortalOpen = false;
		this.slowMotion = false;
		this.universalTime = 1f;
		this.startTime = GameState.getTimestamp ();
	}
	
	public void enableSlowMotion(float coeff)
	{
		this.universalTime = 1f / coeff;
		this.slowMotion = true;
	}
	
	public void disableSlowMotion()
	{
		this.universalTime = 1f;
		this.slowMotion = false;
	}

	public void levelEnd(int level)
	{
		int duration = GameState.getTimestamp () - this.startTime;


		pseudo = "obs";

		if (pseudo != "")
		{

			try
			{
				PostRequest req = new PostRequest(SAVE_URL);
				req.addData("level", (level - 4).ToString());
				req.addData("pseudo", pseudo);
				req.addData("time", duration.ToString());
				req.send();
			}
			catch
			{
				
			}
				
		}

        
		
	}
	
	
	public bool leftPortalOpen { get; set; }
	
	public bool rightPortalOpen { get; set; }
	
	private bool slowMotion;
	public bool SlowMotion {
		get { return this.slowMotion; }
	}
	
	private float universalTime;
	public float UniversalTime {
		get { return this.universalTime; }
	}

	private int startTime;
	public int StartTime
	{
		get { return this.startTime; }
	}
	
}
