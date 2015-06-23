using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour {

	
	public float effect = 10f;
    public float useSpeed = 0.1f;
    public float regenSpeed = 0.05f;
	private GameState gameState = GameState.Instance;
    public GameObject energyBar;
    private MyGui gui;

	// Use this for initialization
	void Start () {
        gui = energyBar.GetComponent<MyGui>();
	}
	
	// Update is called once per frame
	void Update () {

        if(gameState.SlowMotion)
        {
            gui.Life -= useSpeed * Time.deltaTime;
            if(gui.Life == 0)
            {
                gameState.disableSlowMotion();
            }
        }
        else
        {
            gui.Life += regenSpeed * Time.deltaTime;
        }


		if(Input.GetKeyDown("space") && gui.Life != 0)
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
