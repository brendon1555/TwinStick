using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootOnAxisInput : MonoBehaviour {

    public GameObject bullet;
    GameObject gun;

    public float shootDelay = 0.2f;
    public float reloadDelay = 1.5f;

    public bool canShoot = true;
    public int ammoCount = 6;

    public Text ammoText;

	// Use this for initialization
	void Start () {
        gun = GetComponent<GameObject>();
        ammoText.text = ammoCount.ToString();
    }

    void ResetShot()
    {
        canShoot = true;
    }

    void Reload()
    {
        ammoCount = 6;
        ammoText.text = ammoCount.ToString();
        canShoot = true;
    }

    void Shoot(float angle)
    {

        Vector3 offset = transform.rotation * new Vector3(0.7f, 0, 0);

        Instantiate(bullet, transform.position + offset, Quaternion.Euler(new Vector3(0, 0, angle)));

        canShoot = false;
        ammoCount = ammoCount - 1;
        ammoText.text = ammoCount.ToString();
        Debug.Log(ammoCount);

        if (ammoCount == 0)
        {
            ammoText.text = "Reloading...";
            Invoke("Reload", reloadDelay);
        }
        else
        {
            Invoke("ResetShot", shootDelay);
        }
    }

	// Update is called once per frame
	void Update () {

        Vector2 shootDirection = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));


        if(canShoot && Input.GetMouseButton(0))
        {

            Vector2 mousePos = Input.mousePosition;

            Vector2 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Round((Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) / 22.5f) * 22.5f;

            Shoot(angle);
            
        }
        else if (canShoot && shootDirection.magnitude > 0.1f && Input.GetAxis("Shoot") > 0.5f)
        {
            float angle = Mathf.Round((Mathf.Atan2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2")) * Mathf.Rad2Deg) / 22.5f) * 22.5f;

            Shoot(angle);
        }
	
	}
}
