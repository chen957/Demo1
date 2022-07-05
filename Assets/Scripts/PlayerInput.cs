using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //variable
    //自定义按键
    [Header("===========key settings==========")]
    public string keyUp ;
    public string keyDown;
    public string keyRight;
    public string keyLeft;
    public string keyA ="left shift";
    public string keyB = "space";
    public string keyC;
    public string keyD;

    public string keyJUp;
    public string keyJDown;
    public string keyJLeft;
    public string keyJRight;




    [Header("===========output signals==========")]
    public float Dup;
    public float Dright;
    public float Dmag;
    public float JUp;
    public float JRight;
    
    public Vector3 Dvec;
    public bool run;
    public bool jump;
    public bool lastJump;
    //给速度一个加速度 使运动更平滑
    private float targetUp;
    private float targetRight;
    private float velocityUp;
    private float velocityRight;
    private float Dright2;
    private float Dup2;
    //用于接收转换后的移动值
    private Vector2 tar;
    [Header("===========others ==========")]
    public bool inputEnable = true;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JRight = (Input.GetKey(keyJRight) ? 1.0f : 0) - (Input.GetKey(keyJLeft) ? 1.0f : 0);
        JUp = (Input.GetKey(keyJUp) ? 1.0f:0)-(Input.GetKey(keyJDown) ? 1.0f:0);



        targetUp = ((Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0));
        targetRight = ((Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0));
        //取消按键使能
        if (!inputEnable)
        {
            targetUp = 0; 
            targetRight = 0;
        }
         
        Dup = Mathf.SmoothDamp(Dup, targetUp, ref velocityUp, 0.1f); 
        Dright = Mathf.SmoothDamp(Dright, targetRight, ref velocityRight, 0.1f);
        tar = SquareToCircle(new Vector2(Dright, Dup));
        Dup2 = tar.y;
        Dright2 = tar.x;

        Dmag = Mathf.Sqrt(Dup2 * Dup2 + Dright2 * Dright2);
        Dvec = Dright2 * transform.right + Dup2* transform.forward;
        run = Input.GetKey(keyA);

        bool newJump = Input.GetKey(keyB);
        jump = newJump;
        if (newJump!= lastJump && jump ==true)
        {
            jump = true;
            
        }else
        {
            jump = false;
            
        }
        lastJump = newJump;


    }
    
    //处理坐标系，直角转为球面

    private Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output = new Vector2();
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f); ;
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f); ;
        return output;
    }
}
