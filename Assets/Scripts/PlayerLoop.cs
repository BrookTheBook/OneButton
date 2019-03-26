using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoop : MonoBehaviour {

	[SerializeField] GameObject sword;
	[SerializeField] float attackAngle;

	private float distance;

	void Start () 
	{
		sword = transform.Find("Sword").gameObject;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Attack();
	}

	void Attack()
	{
		distance = Mathf.Abs(attackAngle - sword.transform.rotation.z);
		Debug.Log(distance);
		if (distance > 0.1f)
			{
				
				sword.transform.RotateAround(sword.transform.position, sword.transform.forward, Mathf.LerpAngle(sword.transform.rotation.z, attackAngle, 0.001f));
			}
	}
}
