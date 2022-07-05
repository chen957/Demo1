using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//抽象缓存池内部list
public class PoolData
{
    public GameObject fatherObj;
    public List<GameObject> poolList;
    public PoolData(GameObject obj,GameObject poolObj)
    {
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = poolObj.transform; 
        poolList = new List<GameObject>() { obj};
        pushObj(obj);//将首次创建的物体处理
    }
    public void pushObj(GameObject obj)
    {
        obj.SetActive(false);
        poolList.Add(obj);
        obj.transform.parent = fatherObj.transform;
    }
    
    public GameObject getObj()
    {
        GameObject obj = null;
        obj = poolList[0];
        poolList.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.parent = null;
        return obj;
    }

}
public class PoolMgr : BaseMgr<PoolMgr>
{
    public Dictionary<string,PoolData> poolDic = new Dictionary<string,PoolData>();
    private GameObject poolObj;
    public GameObject GetObj(string name)
    {
        GameObject obj = null;
        if (poolDic.ContainsKey(name)&&poolDic[name].poolList.Count>0)
        {
            obj = poolDic[name].getObj();
        }
        else
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name)); 
            obj.name = name;
        }
       

        return obj;
    }
    public void PushObj(string name,GameObject obj)
    {
        if(poolObj == null)
        { 
            poolObj = new GameObject("Pool");
        }
       
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].pushObj(obj);
        }
        else
        {
            poolDic.Add(name, new PoolData(obj,poolObj){ });
        }
        
    }
    //清空缓存池子
    public void Clear()
    {
        poolDic.Clear();
        poolObj = null;
    }
    // Update is called once per frame
    
}
