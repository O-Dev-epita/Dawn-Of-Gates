using UnityEngine;


public class EndElevatorController : ElevatorController {



	void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player")
        {
            closeDoors();
            GameState.Instance.levelEnd(level);
            Invoke("nextLevel", 2);
        }
		
	}
}
