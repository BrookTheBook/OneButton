using UnityEngine;

public class EnemySwordBool : MonoBehaviour
{
    public bool attackActive;
    public GameObject player;
    void DamagePlayer()
    {
		player.GetComponent<PlayerLoop>().playerHP -= 10;
    }
}
