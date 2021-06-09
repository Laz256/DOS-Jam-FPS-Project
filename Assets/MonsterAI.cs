using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public bool attack = false;
    public int randomValue;
    public bool roam = true;
    public Vector3 RoamPosition;
    public CharacterController controller;
    private float y;
    private float speed = 4f;
    public Vector3 Gravity;
    public Vector3 moveDir;
    public Vector3 CurrentRoamPosition;
    public float health = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RoamPosition = new Vector3(Random.Range(-2.5f, 2.5f), y, Random.Range(-2.5f, 2.5f)); //Set random position

        y = transform.position.y;

        distance = Vector3.Distance(transform.position, player.transform.position); //Define distance
        if (distance <= 25f) { attack = true; }  //If true Attack
        else if (distance > 25f) { attack = false; }; //If false don't Attack
        if (attack == true) { Attack(); }; //If true Attack

        if (attack == false) { randomValue = Random.Range(0, 100); }; //Choose random value
        if (randomValue == 50) { roam = true;
            CurrentRoamPosition = RoamPosition;
        }; //If random value 50 go to Roam() & Sets current random value once
        if (roam == true) { Roam(); };

        Gravity = new Vector3(0, -4, 0); //Gravity
        controller.Move(Gravity * Time.deltaTime);

        moveDir = player.transform.position - transform.position; //Set attack direction

        if (health <= 0) { Destroy(gameObject); };
    }
    void Attack()
    {
        controller.Move( moveDir.normalized * speed * Time.deltaTime);
        roam = false;
    }
    void Roam()
    {
        controller.Move(CurrentRoamPosition.normalized * speed/2 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            health -= 1;
        }
    }

}