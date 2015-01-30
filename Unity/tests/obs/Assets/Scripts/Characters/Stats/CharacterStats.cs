using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int maxLife = 100;
	public float dieWait = 0.5f;
	
	
	private int life;
	public int Life {
		get { return life; }
		set {
			if(value < 0) {
				life = 0;
				kill();
			}
			else if(value > maxLife) {
				life = maxLife;
			}
			else {
				life = value;
			}
		}
	}
	
	public void kill() {
		Destroy (gameObject, dieWait);
	}
	
	
	void Start () {
		Life = maxLife;
	}
}
