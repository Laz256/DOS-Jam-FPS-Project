using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Rigidbody rb;
    public CharacterController controller;
    public Transform gun;
    public float speed = 10f;
    public float health = 10;
    public float timer = 0;
    public float KillCounter = 0;
    public Vector3 Gravity;
    public Text healthCounter;
    public float damageTimer = 0;

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //Declare x and z
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime); //Movement one-liner

        Gravity = new Vector3(0, -4, 0);
        controller.Move(Gravity * Time.deltaTime); //Gravity

        if (Input.GetKey("a") & Input.GetKey("d")) { speed = 0f; }
            else if (Input.GetKey("w") & Input.GetKey("s")) { speed = 0f; } //Stop movement bug
                else { speed = 10f; };

        timer += 1 * Time.deltaTime;

        healthCounter.text = ("Health: " + health.ToString());

        damageTimer += 1; //Damage Timer

        if (health <= 0)
        {
            SceneManager.LoadScene("Losing Screen"); //Death on losing all health
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Smg")
        {
            gun.parent = null;
        }
        if (other.tag == "medkit")
        {
            health += 2;
        }
        if (damageTimer >= 50 && other.tag == "enemy")
        {
            health -= 1;
            damageTimer = 0;
        }
    }
}
