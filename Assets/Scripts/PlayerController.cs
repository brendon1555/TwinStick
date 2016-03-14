using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    Rigidbody2D rigid2d;

	// Use this for initialization
	void Start () {
        rigid2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        //{
        //    rigid2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigid2d.velocity.y);
        //}

        //if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        //{
        //    rigid2d.velocity = new Vector2(rigid2d.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        //}



        //if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        //{
        //    rigid2d.velocity = new Vector2(0f, rigid2d.velocity.y);
        //}

        //if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        //{
        //    rigid2d.velocity = new Vector2(rigid2d.velocity.x, 0f);
        //}

        ////rotation
        //Vector3 mousePos = Input.mousePosition;

        //Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.y;

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        Vector2 rbVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        rbVelocity *= moveSpeed;

        rigid2d.velocity = rbVelocity;

        //rotation
        //Vector3 mousePos = Input.mousePosition;

        //Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.y;

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
