using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public int col;
	public int row;
	public GameObject tile;

	private char[,] grid;

	// Use this for initialization
	void Start(){
		grid = new char[col, row];
		GenerateGrid ();
	}

	private void GenerateGrid () {
		for (int i = 0; i < col; i++) {
			for (int j = 0; j < row; j++) {
				Instantiate (tile, new Vector3 (transform.position.x + i, transform.position.y, transform.position.z + j), Quaternion.identity);
				grid [i, j] = 'X';
			}
		}
	}

	public bool checkEnemyInPosition(int x, int y){
        Debug.Log("x = " + x);
        Debug.Log("y = " + y);
		if (grid [x, y] != 'X')
			return true;
		return false;
	}
}
