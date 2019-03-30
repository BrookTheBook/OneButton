using UnityEngine;

public class EnemySwordBool : MonoBehaviour
{
    public bool attackActive, attackHit;
    public GameObject player;
	public float damage;
    void DamagePlayer()
    {
		player = GameObject.Find("Player");
		player.GetComponent<PlayerLoop>().playerHP -= damage;
    }

	void Update()
	{
		if (attackHit == true)
		{
			attackHit = false;
			DamagePlayer();
		}
	}
	
}
