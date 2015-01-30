using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour {

	
	public float effect = 100f;
	private GameState gameState = GameState.Instance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire3"))
		{
			if(gameState.SlowMotion)
			{
				gameState.disableSlowMotion();
			}
			else
			{
				gameState.enableSlowMotion(effect);
			}
		}
	}
}
