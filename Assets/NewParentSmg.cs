using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParentSmg : MonoBehaviour
{
    public gun gunscript;
    public smg smgScript;
    public Transform player;
    public Rotation RotationScript;
    public bool check = false;
    public shoot ShootScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gunscript.doesntHasParent == true & check == false) { ChangeParent(); };
        if (smgScript.ok == true) { 
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localPosition = (Vector3.zero);
        };
    }
    void ChangeParent()
    {
        ShootScript.ammo = 50;
        check = true;
        RotationScript.enabled = false;
        transform.SetParent(player);
    }
}
