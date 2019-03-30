using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour 
{
	public GameObject player, currentEnemy, enemyPrefab;
	public float difficultyFactor;
	float currentAgro;
	int score;
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
				score += 1;
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
		
		currentAgro = currentEnemy.GetComponent<EnemyLoop>().enemyAgro;
		currentEnemy = newEnemy;
		currentEnemy.GetComponent<EnemyLoop>().enemyAgro = currentAgro * difficultyFactor;
		currentAgro = currentEnemy.GetComponent<EnemyLoop>().enemyAgro;
		player.GetComponent<PlayerLoop>().parryCD = currentAgro * 0.75f;
		player.GetComponent<PlayerLoop>().currentEnemy = newEnemy;
	}

	void UpdateUI()
	{
		canvas.transform.Find("Score").GetComponent<Text>().text = score.ToString();
		canvas.transform.Find("Player HP").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().playerHP;
		canvas.transform.Find("Parry CD").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().parryCDTimer;
		canvas.transform.Find("Parry CD").GetComponent<Slider>().maxValue = player.GetComponent<PlayerLoop>().parryCD;
		if (currentEnemy != null)
			currentEnemy.transform.Find("Canvas").transform.Find("Enemy HP").GetComponent<Slider>().value = currentEnemy.GetComponent<EnemyLoop>().enemyHP;
	}
}
