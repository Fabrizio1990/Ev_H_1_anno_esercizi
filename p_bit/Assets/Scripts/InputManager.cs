using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.instance.PlayerInstance != null) 
                SendImpulse(Input.mousePosition);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (GameManager.instance.isGameOver)
                GameManager.instance.ReloadScene();
        }
	
	}

    void SendImpulse(Vector3 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.transform.gameObject.tag == "Terrain")
            {
                Vector3 origin = hitInfo.point;
                GameManager.instance.Impulse(origin);
            }
        }
    }
}
