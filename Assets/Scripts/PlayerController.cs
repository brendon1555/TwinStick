using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    Rigidbody2D rigid2d;
    public GameObject gun;

    Animator anim;

	// Use this for initialization
	void Start () {
        rigid2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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


        Vector2 rbVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rbVelocity *= moveSpeed;
        rigid2d.velocity = rbVelocity;

        if(rbVelocity.sqrMagnitude > 0.01f)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

        Vector2 stickDirection = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        if (stickDirection.magnitude > 0.1f)
        {
            float angle = Mathf.Round((Mathf.Atan2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2")) * Mathf.Rad2Deg) / 22.5f) * 22.5f;
            gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 objectPos = Camera.main.WorldToScreenPoint(gun.transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            float angle = Mathf.Round((Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) / 22.5f) * 22.5f;
            Debug.Log(angle);
            gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (gun.transform.eulerAngles.z > 90 && gun.transform.eulerAngles.z < 270)
        {
            gun.transform.localScale = new Vector3(1f, -1f, 1f);
        }
        else if (gun.transform.eulerAngles.z <= 90 || gun.transform.eulerAngles.z >= 270)
        {
            gun.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //rotation
        //Vector3 mousePos = Input.mousePosition;

        //Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.y;

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
