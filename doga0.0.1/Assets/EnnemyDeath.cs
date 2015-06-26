using UnityEngine;
using System.Collections;

public class EnnemyDeath : MonoBehaviour {

    public int life = 2;
    public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("blabla : " + other.name + " " + life);
        if(other.tag == "shuriken")
        {
            life--;
            Destroy(other);
            if(life == 0)
            {
                anim.SetBool("Dead", true);
            }
        }
    }
}
