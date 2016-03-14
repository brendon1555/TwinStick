using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    transform.position += transform.right*moveSpeed*Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
