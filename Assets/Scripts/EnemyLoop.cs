using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoop : MonoBehaviour
{

    GameObject sword;
    Animator swordAnim;
    float attackCD;
    public float enemyAgro, enemyHP = 100, randomizer, firstAttackDelay = 2;


    void Start()
    {
        sword = transform.Find("EnemySword").gameObject;
        swordAnim = sword.GetComponent<Animator>();
        attackCD = enemyAgro;

        randomizer = Random.Range(-2.0f, 0.0f);
    }
    void Update()
    {
        if (attackCD <= randomizer - firstAttackDelay)
            Attack();
        attackCD -= Time.deltaTime;
    }

    void Attack()
    {
        firstAttackDelay = 0;
        int coinFlip = Random.Range(0, 2);
        if (coinFlip == 0)
            swordAnim.Play("EnemyAttack");
		else
			swordAnim.Play("EnemyFeint");
        attackCD = enemyAgro;
        randomizer = Random.Range(-2.0f, 0.0f);
    }

    public void Parried()
    {
        swordAnim.Play("EnemyParried");
    }
}
