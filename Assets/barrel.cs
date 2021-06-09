using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    public GameObject explosion;
    public float random;
    public float random2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        random2 = Random.Range(-2, 2);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            random = Random.Range(0,5);
            for (int i = 0; i < random; i++)
            {
                Instantiate(explosion, new Vector3(transform.position.x + random2, transform.position.y, transform.position.z), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
