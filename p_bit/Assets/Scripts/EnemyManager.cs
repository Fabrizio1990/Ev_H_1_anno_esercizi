using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemyModel;
	public Material[] matEnemy;

    public float enemySpawnTime;
    private float timer;



    private enum enemyType {
		enemyNormal,	// 0
		enemyRay		// 1
    }
	private enemyType enemy;

    void Start()
    {
        InvokeRepeating("spawnRandomEnemy", 2f, enemySpawnTime);
    }

    private void spawnRandomEnemy(){
		

		enemy    = (enemyType)Random.Range(0, System.Enum.GetValues(typeof(enemyType)).Length);
        int posX = Random.Range(0, GameManager.instance.gridManager.col);
        int posY = Random.Range(0, GameManager.instance.gridManager.row);

        Vector3 position = new Vector3(posX, 0.5f, posY);

		if (GameManager.instance.gridManager.checkEnemyInPosition (posX, posY))
			spawnRandomEnemy ();

		GameObject temp = Instantiate (enemyModel, position, Quaternion.identity) as GameObject;
		temp.tag = "Enemy";
		Enemy enemyScript = temp.GetComponent<Enemy> ();

		switch (enemy) {
		case enemyType.enemyNormal:
			enemyScript.rotation = 0.0f;
			enemyScript.shootDistance = 0.0f;
			enemyScript.isMoving = false;
			enemyScript.isShooting = false;
			break;
		case enemyType.enemyRay:
			enemyScript.rotation = 90.0f;
			enemyScript.shootDistance = 5.0f;
			enemyScript.isMoving = true;
			enemyScript.isShooting = true;
			break;
		}

		temp.GetComponent<Renderer> ().material = GetMaterialFromType(enemy);
	

	}

	private Material GetMaterialFromType(enemyType id){

		Material result;

		switch (id) {
		case enemyType.enemyNormal:
			result = matEnemy [1];
			break;
		case enemyType.enemyRay:
			result = matEnemy [2];
			break;
		default:
			result = matEnemy [0];
			break;
		}

		return result;
	}
		
}
