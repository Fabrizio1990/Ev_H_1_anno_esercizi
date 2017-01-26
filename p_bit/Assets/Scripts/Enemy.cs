using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int id;
	public bool isMoving;
	public bool isShooting;
	public float rotation;
	public float shootDistance;
	public float timeToRotate = 1.0f;
	public float timeToShoot = .15f;
    public Transform shootPosition;

	private float timerRotate = 0.0f;
	private float timerShoot = 0.0f;
	private LineRenderer line;

	void Awake(){
		line = GetComponent<LineRenderer> ();
		line.enabled = (isShooting) ? true : false;
	}

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, GameManager.instance.timeToDestroyEnemy);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			if (timerRotate < timeToRotate) {
				timerRotate += Time.deltaTime;
			} else {
				transform.RotateAround (transform.position, Vector3.up, rotation);
				timerRotate = 0.0f;
			}
		}

		if (isShooting) {
			if (timerShoot < timeToShoot) {
				timerShoot += Time.deltaTime;
				line.enabled = false;
			} else {
				RaycastHit hit;

				StopCoroutine (ShootLine());
				StartCoroutine (ShootLine());

                Debug.DrawRay(shootPosition.position, transform.forward *shootDistance, Color.red);
				if (Physics.Raycast (shootPosition.position, transform.forward, out hit, shootDistance)) {
                    
					if (hit.collider.gameObject.tag == "Player") {
                        Player playerScript  = hit.collider.gameObject.GetComponent<Player>();
                        playerScript.Die();
                    }
				}
				timerShoot = 0.0f;
			}

		}
	}

	void OnDestroy(){
		GameManager.instance.gridManager.RemoveEnemyInCoord (Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
	}

	IEnumerator ShootLine(){
		line.enabled = true;

		while (true) {
			Ray ray = new Ray(transform.position, transform.forward);

			line.SetPosition (0, ray.origin);
			line.SetPosition (1, ray.GetPoint (shootDistance));

			yield return null;
		}
	}
}
