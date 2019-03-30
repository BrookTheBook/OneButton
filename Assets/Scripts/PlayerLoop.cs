using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoop : MonoBehaviour
{

    GameObject sword;
    Animator swordAnim;
    public float parryCD, playerHP, parryCDtimer;
    public GameObject currentEnemy;


    void Start()
    {
        sword = transform.Find("Sword").gameObject;
        swordAnim = sword.GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) == true && parryCDtimer >= 2)
        {
            Parry();
        }

        if (sword.GetComponent<SwordBool>().parryActive == true &&
            currentEnemy.transform.Find("EnemySword").GetComponent<EnemySwordBool>().attackActive == true)
        {
            Debug.Log("PARRIED");
            Attack();
        }


        parryCDtimer += Time.deltaTime;
    }

    void Attack()
    {
        swordAnim.Play("Attack");
        currentEnemy.GetComponent<EnemyLoop>().enemyHP -= 10;
    }

    void Parry()
    {
        parryCDtimer = parryCD;
        swordAnim.Play("Parry");
    }
}
