using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public int col;
	public int row;
	public GameObject tile;
	public GameObject BoundsPrefab;

	private char[,] grid;

	// Use this for initialization
	void Start(){
		grid = new char[col, row];
		GenerateGrid ();
		GenerateBounds ();
	}

	private void GenerateGrid () {
		for (int i = 0; i < col; i++) {
			for (int j = 0; j < row; j++) {
				Instantiate (tile, new Vector3 (transform.position.x + i, transform.position.y, transform.position.z + j), Quaternion.identity);
				grid [i, j] = 'X';
			}
		}
	}

	private void GenerateBounds(){
		for(int i = 0; i < 2; i ++){
			GameObject temp = Instantiate (BoundsPrefab, new Vector3 ((i - 1) + (col * i), 0.0f, row / 2), Quaternion.identity) as GameObject;
			temp.name = (i == 0) ? "Bound SX" : "Bound DX";
			BoxCollider bound = temp.GetComponent<BoxCollider> ();

			float boundZ = 0.0f;
			if (col != row) {
				boundZ = (col > row) ? (bound.size.z + col / 2) : (bound.size.z + col * 2);
			} else {
				boundZ = col + 1;
			}
			bound.size = new Vector3 (bound.size.x, bound.size.y + 5.0f, boundZ);

		}

		for(int i = 0; i < 2; i ++){
			GameObject temp = Instantiate (BoundsPrefab, new Vector3 (col / 2, 0.0f, (i - 1) + (row * i)),  Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f))) as GameObject;
			temp.name = (i == 0) ? "Bound BOTTOM" : "Bound TOP";
			BoxCollider bound = temp.GetComponent<BoxCollider> ();

			float boundZ = 0.0f;
			if (col != row) {
				boundZ = (col > row) ? (bound.size.z + row * 2) : (bound.size.z + row / 2);
			} else {
				boundZ = row + 1;
			}
			bound.size = new Vector3 (bound.size.x, bound.size.y + 5.0f, boundZ);
	
		}
	}

	public bool checkEnemyInPosition(int x, int y){
		if (grid [x, y] != 'X')
			return true;
		return false;
	}

	public void RemoveEnemyInCoord(int x, int y){
		grid [x, y] = 'X';
	}
}
