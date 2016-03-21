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


        Vector2 rbVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rbVelocity *= moveSpeed;
        rigid2d.velocity = rbVelocity;

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
  

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
    }
}
