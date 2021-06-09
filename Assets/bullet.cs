using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    private float y;
    private float z;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= 30f) { Destroy(gameObject); };
        y = transform.eulerAngles.y;
        z = transform.eulerAngles.z;
        transform.rotation = Quaternion.Euler(270,y,z);
        rb.velocity = -transform.up * 16;
    }
    void OnCollisionEnter(Collision collider)
    {
        Destroy(gameObject);
    }
}
