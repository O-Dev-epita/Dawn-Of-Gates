using UnityEngine;
using System.Collections;

public class DallesManager : MonoBehaviour {

    public GameObject otherDalle;
    public GameObject leftDoor;
    public GameObject rightDoor;

    private bool activated = false;
    public bool Activated
    {

        get { return activated;  }
    }

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter()
    {
        activated = true;
        if(otherDalle.GetComponent<DallesManager>().activated)
        {
            leftDoor.animation.Play();
            rightDoor.animation.Play();
        }
    }
}
