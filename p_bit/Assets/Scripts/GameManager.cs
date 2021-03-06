﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public Transform spawnPosition;
	public GameObject playerPrefab;
    [HideInInspector]
	public GameObject PlayerInstance;
    public Text gameOverText;

    public float timeToDestroyEnemy = 3.0f;
	public float inpulseMaxRange;

    [HideInInspector]
    public Player playerScript;
    [HideInInspector]
    public GridManager gridManager;
    [HideInInspector]
    public EnemyManager enemyManager;

    [HideInInspector]
    public bool isGameOver;
   

	void Awake(){
        instance = this;
        gridManager = GetComponent<GridManager>();
        enemyManager = GetComponent<EnemyManager>();

    }
	void Start () {
        Vector3 PlayerSpawnposition = new Vector3(gridManager.col / 2, 0.5f, gridManager.row / 2);
		PlayerInstance  = Instantiate (playerPrefab, PlayerSpawnposition, playerPrefab.transform.rotation) as GameObject;
        playerScript    = PlayerInstance.GetComponent<Player>();

    }
	


	public void Impulse(Vector3 origin){
        float distance = Vector3.Distance(PlayerInstance.transform.position, origin);
        if(distance <= inpulseMaxRange) { 
			Vector3 direction = (PlayerInstance.transform.position - origin).normalized;
            direction *= distance;
            playerScript.Move(direction);
        }

    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.enabled = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
