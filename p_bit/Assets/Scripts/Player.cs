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
    
    public void Move(Vector3 force)
    {
		rb.AddForce(force * speed *Time.fixedDeltaTime,ForceMode.Impulse);
    }

    public void Die()
    {
        Destroy(this.gameObject);
        GameManager.instance.GameOver();
    }
}
