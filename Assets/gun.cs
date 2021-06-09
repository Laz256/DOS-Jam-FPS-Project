using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float MouseInput;
    public bool doesntHasParent = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput = Input.GetAxisRaw("Fire1");
        animator.SetFloat("Blend" , MouseInput);

        if (transform.parent.parent != player) {
            Destroy(gameObject);
            doesntHasParent = true; };
    }
}
