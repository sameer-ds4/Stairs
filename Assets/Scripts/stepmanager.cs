using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepmanager : MonoBehaviour
{
    public Vector3 spawn;
    public float time;
    public float maxt;
    void spawner()
    {
        GameObject obj = objectpool.instance.getpooledobject();
        obj.transform.position = spawn;
        Debug.Log(obj);
        obj.SetActive(true);
    }
        // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= maxt)
        {
            spawner();
            time = 0;
        }    
    }

}
