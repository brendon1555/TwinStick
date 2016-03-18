using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int health = 5;

    public float moveSpeed = 5f;
    Rigidbody2D rigid2d;
    Transform Player;

    void Start ()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (health <= 0)
        {
            Die();
        }

        Player = GameObject.Find("Player").transform;

        float y2 = Player.position.y - transform.position.y;
        float x2 = Player.position.x - transform.position.x;


        Vector2 rbVelocity = new Vector2(x2, y2).normalized;
        rbVelocity *= moveSpeed;
        rigid2d.velocity = rbVelocity;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            health--;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
