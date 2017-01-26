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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo, Mathf.Infinity))
            {
                if(hitInfo.transform.gameObject.tag == "Terrain") {
                    Vector3 origin = hitInfo.point;
                    GameManager.instance.Impulse(origin);
                }
            }
        }
	
	}
}
