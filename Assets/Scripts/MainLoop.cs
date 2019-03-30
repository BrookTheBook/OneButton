using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour 
{
	public GameObject player, currentEnemy, enemyPrefab, sun;
	public float difficultyFactor;
	float currentAgro;
	int score;
	public Canvas playCanvas, deathCanvas;
	
	void Start () 
	{
		player.GetComponent<PlayerLoop>().currentEnemy = currentEnemy;

	}

	void Update() 
	{
		sun.transform.Rotate(0.1f,0.2f,0.3f);
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
			playCanvas.GetComponent<Canvas>().enabled = false;
			deathCanvas.transform.Find("Score").GetComponent<Text>().text = score.ToString();
			deathCanvas.GetComponent<Canvas>().enabled = true;
			if (Input.GetKey(KeyCode.Mouse0))
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
		playCanvas.transform.Find("Score").GetComponent<Text>().text = score.ToString();
		playCanvas.transform.Find("Player HP").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().playerHP;
		playCanvas.transform.Find("Parry CD").GetComponent<Slider>().value = player.GetComponent<PlayerLoop>().parryCDTimer;
		playCanvas.transform.Find("Parry CD").GetComponent<Slider>().maxValue = player.GetComponent<PlayerLoop>().parryCD;
		if (currentEnemy != null)
			currentEnemy.transform.Find("Canvas").transform.Find("Enemy HP").GetComponent<Slider>().value = currentEnemy.GetComponent<EnemyLoop>().enemyHP;
	}
}
