using UnityEngine;

public class EnemySwordBool : MonoBehaviour
{
    public bool attackActive, attackHit;
    public GameObject player;
	public float damage;
	public AudioClip damaged;
    void DamagePlayer()
    {
		player = GameObject.Find("Player");
		player.GetComponent<PlayerLoop>().playerHP -= damage;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(damaged);
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
