using UnityEngine;
using System.Collections;

public class PlayerStats : CharacterStats {

	public int maxEnergy = 500;
	public float lifeRegenDelay = 2f;
	public int lifeRegenValue = 50;
	public float energyRegenDelay = 2f;
	public int energyRegenValue = 50;

	private float lastLifeRegen;
	private float lastEnergyRegen;

	private int energy;
	public int Energy {
		get { return energy; }
		set {
			if(value < 0) {
				energy = 0;
			}
			else if(value > maxEnergy) {
				energy = maxEnergy;
			}
			else {
				energy = value;
			}
		}
	}

	// Use this for initialization
	void Start () {
		Life = maxLife;
		Energy = maxEnergy;
		lastLifeRegen = 0f;
		lastEnergyRegen = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		lastLifeRegen += Time.deltaTime;
		lastEnergyRegen += Time.deltaTime;

		if (lastLifeRegen > lifeRegenDelay) {
				Life += lifeRegenValue;
				lastLifeRegen -= lifeRegenDelay;
		}
		if (lastEnergyRegen > energyRegenDelay) {
			Energy += energyRegenValue;
			lastEnergyRegen -= energyRegenDelay;
		}



	}
}
