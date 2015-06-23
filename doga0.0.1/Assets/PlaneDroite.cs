using UnityEngine;
using System.Collections;

public class PlaneDroite : MonoBehaviour {

    public DallesManager dm;

    private bool playerIn = false;
    public bool PlayerIn {
        get { return playerIn; }
    }

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

        if(dm.Activated)
        {
            playerIn = false;
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!dm.Activated && other.tag == "Player")
        {
            playerIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIn = false;
        }
        
    }
}
