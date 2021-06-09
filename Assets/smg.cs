using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smg : MonoBehaviour
{
    public NewParentSmg ParentScript;
    public bool ok = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ParentScript.check == true & ok == false) {
            ok = true;
            transform.localPosition = new Vector3(7.5f, -9, 8);
            transform.localRotation = Quaternion.Euler(270,10,270);};
    }
}
