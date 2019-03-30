using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoop : MonoBehaviour
{

    GameObject sword;
    Animator swordAnim;
    public float parryCD, playerHP, parryCDTimer, damage;
    public GameObject currentEnemy;
    public AudioClip parryClip, damageClip;


    void Start()
    {
        sword = transform.Find("Sword").gameObject;
        swordAnim = sword.GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) == true && parryCDTimer >= parryCD)
        {
            Parry();
        }

        if (currentEnemy != null && sword.GetComponent<SwordBool>().parryActive == true &&
            currentEnemy.transform.Find("EnemySword").GetComponent<EnemySwordBool>().attackActive == true)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(parryClip);
            currentEnemy.GetComponent<EnemyLoop>().Parried();
            Attack();
        }


        parryCDTimer += Time.deltaTime;
    }

    void Attack()
    {
        swordAnim.Play("Attack");
        Camera.main.GetComponent<AudioSource>().PlayOneShot(damageClip);
        currentEnemy.GetComponent<EnemyLoop>().enemyHP -= damage;
    }

    void Parry()
    {
        parryCDTimer = 0;
        swordAnim.Play("Parry");
    }
}
