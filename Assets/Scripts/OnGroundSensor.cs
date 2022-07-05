using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour
{
    // Start is called before the first frame update
    public CapsuleCollider capsule1;

    private Vector3 point1;
    private Vector3 point2;
    private float radius;
    private float offest = 0.5f;

    private void Awake()
    {
        radius =capsule1.radius - 0.1f;
    }

   
    // Update is called once per frame
    void FixedUpdate()
    {
        point1 = transform.position+transform.up*(radius-offest);
        point2 = transform.position+transform.up*(capsule1.height-offest) -transform.up*radius;
        Collider[] outputCols = Physics.OverlapCapsule(point1, point2, radius,LayerMask.GetMask("Ground"));
        if (outputCols.Length > 0)
        {
            //foreach (Collider col in outputCols)
            //{
            //    print(col.name);

            //}
            SendMessageUpwards("IsGround");
        }
        else
        {
            SendMessageUpwards("IsNotGround");
        }
        
    }
}
