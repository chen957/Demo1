using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public GameObject model;
    public PlayerInput pi;
    public float speed = 2f;
    public float runMultiplier = 2.0f;
    public float jumpVelocity = 1.0f;
    public float rollVelocity = 1.0f;
    

    
    [SerializeField]
    private Animator anim;
    private Rigidbody rig;
    private Vector3 planarVec;
    private Vector3 thrustVec;
    private bool lockPlanar = false;
    void Awake()
    {
        pi = GetComponent<PlayerInput>();
        anim = model.GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //处理跑步动作平滑
        anim.SetFloat("forward", Mathf.Lerp(anim.GetFloat("forward"), pi.Dmag * ((pi.run) ? runMultiplier : 1.0f),0.3f));
        if (pi.jump)
        {
            anim.SetTrigger("jump");
        }
        //锁定转向
        if(pi.Dmag > 0.1f) {
            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec,0.2f);
             
        }
        //
        if (false == lockPlanar) {
            planarVec = pi.Dmag * model.transform.forward;
        }
        if (rig.velocity.magnitude>1.0f )
        {
            anim.SetTrigger("roll");
        }
    }
    private void FixedUpdate()
    {
        rig.position += planarVec * Time.fixedDeltaTime * speed * ((pi.run) ? runMultiplier : 1.0f) +  thrustVec ; 
        thrustVec = Vector3.zero;
    }
    public void OnJumpEnter()
    {
        pi.inputEnable = false;
        lockPlanar = true;
        thrustVec = new Vector3(0,jumpVelocity,0);
        
    }
    //public void OnJumpExit()
    //{
    //    pi.inputEnable = true;
    //    lockPlanar = false;
    //    //print("i m jump!");
    //}
    public void IsGround()
    {
        anim.SetBool("isGround",true);
        print(" on ground");


    }
    public void IsNotGround()
    {
        anim.SetBool("isGround",false);
        

        print("not on ground");
    }
    public void OnGroundEnter()
    {
        pi.inputEnable = true;
        lockPlanar = false;
    }
    public void OnFallEnter()
    {
        pi.inputEnable = false;
        lockPlanar = true;
    }
    public void OnRollEnter()
    {
        pi.inputEnable = false;
        lockPlanar = true;
        thrustVec = new Vector3(0, rollVelocity, 0);
    }
    public void OnJabEnter()
    {
        pi.inputEnable = false;
        lockPlanar = true;
        
    }
    public void OnJabUpdate()
    {
        thrustVec =model.transform.forward*anim.GetFloat("JabVelocity");
    }
}
