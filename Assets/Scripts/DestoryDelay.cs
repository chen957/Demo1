using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("push", 3);
    }

    // Update is called once per frame
    void push()
    {
     PoolMgr.GetInstance().PushObj(this.gameObject.name,this.gameObject);   
    }
}
