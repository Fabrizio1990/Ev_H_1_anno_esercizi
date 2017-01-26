using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public Transform spawnPosition;
	public GameObject playerPrefab;
    [HideInInspector]
	public GameObject PlayerInstance;
	
    
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
            Vector3 direction = PlayerInstance.transform.position - origin;
            direction *= distance;
            playerScript.Move(direction);
        }

    }

}
