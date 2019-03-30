using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour 
{
	public GameObject player, currentEnemy, enemyPrefab;
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
				currentEnemy.GetComponent<Animator>().Play("EnemyDeath");
				currentEnemy.transform.Find("EnemySword").GetComponent<Animator>().Play("EnemySwordDeath");
				Destroy(currentEnemy, 2);
				SpawnEnemy();
			}

		if (player.GetComponent<PlayerLoop>().playerHP <= 0)
		{
			SceneManager.LoadScene("MainScene");

		}
	}
	void SpawnEnemy()
	{
		GameObject newEnemy = Instantiate(enemyPrefab);
		currentEnemy = newEnemy;
		player.GetComponent<PlayerLoop>().currentEnemy = newEnemy;
	}

	void UpdateUI()
	{
		canvas.transform.Find("Player HP").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().playerHP;
		canvas.transform.Find("Parry CD").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().parryCDtimer;
		if (currentEnemy != null)
			currentEnemy.transform.Find("Canvas").transform.Find("Enemy HP").GetComponent<Slider>().value = currentEnemy.GetComponent<EnemyLoop>().enemyHP;
	}
}
