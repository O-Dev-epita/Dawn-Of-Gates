using UnityEngine;
using System.Collections;

public class turretspawn : MonoBehaviour {

	private Transform target;
	private Vector3 targetpoint;
	private Quaternion targetRotation;
	public Turret turret;

	void Start()
	{
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Update()
	{
		targetpoint = target.position;
		targetRotation = Quaternion.LookRotation(targetpoint - transform.position,Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3.0f);

	}

	public Transform getTr()
	{
		return transform;
	}
}
