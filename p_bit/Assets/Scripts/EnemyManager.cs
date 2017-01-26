﻿using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemyModel;
	public Material[] matEnemy;

	private enum enemyType {
		enemyNormal,	// 0
		enemyRay		// 1
	}
	private enemyType enemy;

	public void spawnRandomEnemy(int enemyID, Vector3 position){
		
		enemy = (enemyType)enemyID;

		float rotation = 0.0f;
		float shootDistance = 0.0f;
		bool isMoving = false;
		bool isShooting = false;

		switch (enemy) {
		case enemyType.enemyNormal:
			break;
		case enemyType.enemyRay:
			rotation = 90.0f;
			shootDistance = 5.0f;
			isMoving = true;
			isShooting = true;
			break;
		}

		GameObject temp = Instantiate (enemyModel, position, Quaternion.identity) as GameObject;
		temp.tag = "Enemy";
		Enemy enemyScript = temp.GetComponent<Enemy> ();
		enemyScript.rotation = rotation;
		enemyScript.shootDistance = shootDistance;
		enemyScript.isMoving = isMoving;
		enemyScript.isShooting = isShooting;
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
