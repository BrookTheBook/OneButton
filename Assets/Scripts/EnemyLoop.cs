using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoop : MonoBehaviour {

	GameObject sword;
	Animator swordAnim;
	float attackCD;
	public float enemyAgro;
	public float enemyHP= 100;

	void Start()
    {
        sword = transform.Find("EnemySword").gameObject;
        swordAnim = sword.GetComponent<Animator>();
		attackCD = enemyAgro;

    }
	void Update () 
	{
		if (attackCD <= 0)
			Attack();
		attackCD -= Time.deltaTime;
	}

	void Attack()
	{
		swordAnim.Play("EnemyAttack");
		attackCD = enemyAgro;
	}
}
