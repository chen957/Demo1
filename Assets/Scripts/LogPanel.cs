using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogPanel : BasePanel
{
    void Start()
    {


        GetControl<Button>("beginButton").onClick.AddListener(Fun);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void Fun()
    {
        SceneManager.LoadScene("PoolDemo",LoadSceneMode.Additive);
    }
     void LoadLevel(int level)
    {
            
    }
}
