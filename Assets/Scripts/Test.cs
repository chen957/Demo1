using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolMgr.GetInstance().GetObj("Test/Cube");
        }
        if (Input.GetMouseButtonDown(1))
        {
            PoolMgr.GetInstance().GetObj("Test/Sphere");
        }
    }
    
        
}
