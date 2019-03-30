using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoop : MonoBehaviour {

	GameObject sword;
	Animator swordAnim;
	float attackCD;
	public float enemyAgro;
	public float enemyHP= 100;
	public float randomizer;

	void Start()
    {
        sword = transform.Find("EnemySword").gameObject;
        swordAnim = sword.GetComponent<Animator>();
		attackCD = enemyAgro;
		
		randomizer = Random.Range(-2.0f, 0.0f);
    }
	void Update () 
	{
		if (attackCD <= randomizer)
			Attack();
		attackCD -= Time.deltaTime;
	}

	void Attack()
	{
		swordAnim.Play("EnemyAttack");
		attackCD = enemyAgro;
		randomizer = Random.Range(-2.0f, 0.0f);
	}

	public void Parried()
	{
		swordAnim.Play("EnemyParried");
	}
}
