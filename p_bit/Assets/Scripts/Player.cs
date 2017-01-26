using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;

    Rigidbody rb;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void Move(Vector3 force)
    {
        rb.AddForce(force * speed *Time.deltaTime,ForceMode.Impulse);
    }
}
