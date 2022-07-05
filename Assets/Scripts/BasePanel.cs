using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    protected Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();
    
    void Awake()
    {
        FindChildrenContol<Button>();
        FindChildrenContol<Text>();
        FindChildrenContol<Image>();
        FindChildrenContol<Toggle>();
        FindChildrenContol<Slider>();
        FindChildrenContol<ScrollRect>();
    }


    protected T GetControl<T>(string controlName) where T:UIBehaviour
    {
        if (controlDic.ContainsKey(controlName))
        {
            for(int i = 0; i < controlDic[controlName].Count; i++)
            {
                if(controlDic[controlName][i] is T)
                {
                    return controlDic[controlName][i] as T;
                }
            }
        }
        return null;
    }




    //寻找panel下所有组件
    protected void FindChildrenContol<T>()where T : UIBehaviour
    {
        string objName;
        T[] controls =this.GetComponentsInChildren<T>();
        for(int i = 0; i < controls.Length; i++)
        {
            objName = controls[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
            {
                controlDic[objName].Add(controls[i]);
            }
            else
            {
                controlDic.Add(objName,new List<UIBehaviour>(){ controls[i]});
            }
           
        }
    }
}
