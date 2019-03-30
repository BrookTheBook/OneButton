using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLoop : MonoBehaviour 
{
	public GameObject player, currentEnemy;
	public Canvas canvas;
	void Start () 
	{
		player.GetComponent<PlayerLoop>().currentEnemy = currentEnemy;
	}

	void Update() 
	{
		UpdateUI();

		if (currentEnemy != null && currentEnemy.GetComponent<EnemyLoop>().enemyHP <= 0)
			{
				Destroy(currentEnemy);
				SpawnEnemy();
			}
	}
	void SpawnEnemy()
	{

	}

	void UpdateUI()
	{
		canvas.transform.Find("Player HP").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().playerHP;
		canvas.transform.Find("Parry CD").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().parryCDtimer;
		if (currentEnemy != null)
			currentEnemy.transform.Find("Canvas").transform.Find("Enemy HP").GetComponent<Slider>().value = currentEnemy.GetComponent<EnemyLoop>().enemyHP;
	}
}
