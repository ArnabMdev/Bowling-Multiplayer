using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscript : MonoBehaviour
{
    public bool ended = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ended = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ended = false;
    }
}
