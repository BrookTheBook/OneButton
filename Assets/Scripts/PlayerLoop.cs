using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoop : MonoBehaviour
{

    GameObject sword;
    [SerializeField] float attackAngle;

    [SerializeField] float attackSpeed;
    [SerializeField] float stanceSpeed;
    [SerializeField] float parryWindow;
    [SerializeField] Transform guardPosition;
    [SerializeField] Transform attackPosition;
    public bool parry, guard;

    float parryTimer;


    Quaternion swordStartRotation;
    float lerpAngle;

    void Start()
    {
        sword = transform.Find("Sword").gameObject;
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0) && parry == false && guard == false)
            Attack();

        if (Input.GetKey(KeyCode.Mouse0))
			guard = true;
            Guard();
		
		if(Input.GetKeyUp(KeyCode.Mouse0))
			guard = false;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            parry = true;
            parryTimer = 0;
        }

        if (parry == true)
            Parry();

		


    }

    void Attack()
    {
        sword.transform.localEulerAngles = new Vector3(20, 90, Mathf.PingPong(Time.time * attackSpeed, attackAngle));
        //DPS
    }

    void Guard()
    {
        sword.transform.rotation = Quaternion.Lerp(sword.transform.rotation, guardPosition.rotation, Time.deltaTime * stanceSpeed);
    }

    void Parry()
    {
        parryTimer += Time.deltaTime;
        Debug.Log(parryTimer);
        if (parryTimer > parryWindow)
        {
            parry = false;
        }
    }
}
