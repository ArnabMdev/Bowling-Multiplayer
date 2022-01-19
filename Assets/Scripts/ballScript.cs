using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ballScript : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roll(float direction,float force)
    {
        //-2.54 to 1.82 
        Vector3 loc = new Vector3(-2.54f + direction * 0.04f, transform.position.y, transform.position.z);
        transform.position = loc;
        
        Vector3 pos = new Vector3(loc.x, -2.2f, -17.82f);
        rb.AddForceAtPosition((Vector3.forward) * force *20f, pos);
        
    }

    public void respawn()
    {
        transform.position = startpos;
    }
}
