using UnityEngine;
using System.Collections;

public class ShootOnAxisInput : MonoBehaviour {

    public GameObject bullet;

    public float shootDelay = 0.1f;

    public bool canShoot = true;

	// Use this for initialization
	void Start () {
	
	}

    void ResetShot()
    {
        canShoot = true;
    }

	// Update is called once per frame
	void Update () {

        Vector2 shootDirection = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));


        if(canShoot && Input.GetMouseButton(0))
        {

            //float angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //transform.rotation = );

            Vector2 mousePos = Input.mousePosition;

            Vector2 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));

            canShoot = false;
            Invoke("ResetShot", shootDelay);
        }
        else if (canShoot && shootDirection.magnitude > 0.1f && Input.GetAxis("Shoot") > 0.5f)
        {
            float angle = Mathf.Atan2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2")) * Mathf.Rad2Deg;

            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));

            canShoot = false;
            Invoke("ResetShot", shootDelay);
        }
	
	}
}
