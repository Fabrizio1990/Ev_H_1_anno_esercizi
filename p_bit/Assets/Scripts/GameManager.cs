using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public Transform spawnPosition;
	public GameObject playerPrefab;
    [HideInInspector]
	public GameObject PlayerInstance;
	public float enemySpawnTime;
    [HideInInspector]
    public bool isGameOver;
	public float inpulseMaxRange;
	// Use this for initialization

	Player playerScript;
	float timer;

	void Awake(){
        instance = this;

	}
	void Start () {
		PlayerInstance  = Instantiate (playerPrefab, spawnPosition.position, playerPrefab.transform.rotation) as GameObject;
        playerScript    = PlayerInstance.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Impulse(Vector3 origin){
        float distance = Vector3.Distance(PlayerInstance.transform.position, origin);
        if(distance <= inpulseMaxRange) { 
            Vector3 direction = PlayerInstance.transform.position - origin;
            direction *= distance;
            Debug.Log(distance);
            playerScript.Move(direction);
        }

    }

}
