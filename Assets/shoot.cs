using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    public smg smgScript;
    public GameObject bullet;
    public float timer = 0;
    public float ammo = 50;
    public NewParentSmg ParentScript;
    public float minTimer = 15;
    public Text BulletCount;
    public string ammostring = "Ammo:";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 1;
        if (Input.GetAxisRaw("Fire1") == 1 & timer >= minTimer & ammo >= 1) { Shoot(); };

        if (smgScript.ok == true) { transform.localPosition = new Vector3(0.95f,-0.4f,2f); };

        if (ParentScript.check == true) { minTimer = 10; };

        BulletCount.text = (ammostring + ammo.ToString());
    }
    void Shoot()
    {
        timer = 0;
        ammo -= 1;
        Instantiate(bullet,transform.position,transform.rotation);
    }
}
