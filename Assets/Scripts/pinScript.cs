using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinScript : MonoBehaviour
{
    public int fell = 0;
    public Transform[] transforms;
    // Start is called before the first frame update
    void Start()
    {
        transforms = GetComponentsInChildren<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void check()
    {
        int i = 0;
        for (i = 0; i < transforms.Length; i++)
        {
            if (Mathf.Abs(transforms[i].eulerAngles.x) >= 45f || Mathf.Abs(transforms[i].eulerAngles.y)>=45f  )
            {
                transforms[i].gameObject.SetActive(false);
                fell++;
            }
        }
    }
}
