using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpool : MonoBehaviour
{
    public static objectpool instance;
    public GameObject pooledobject;
    public float poolamount;
    public Transform loc;
    public int i,j;
    [SerializeField] private List<GameObject> pooledobjects;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        pooledobjects = new List<GameObject>();
        for(i = 0; i < poolamount; i++)
        {
            GameObject objfix = Instantiate(pooledobject, loc.position, loc.rotation);
            loc.transform.position = new Vector3(loc.position.x + 1.5f, loc.position.y + 0.7f);
        }

        for (i = 0; i < (poolamount); i++)
        {
            GameObject obj = Instantiate(pooledobject);
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }
    }

    public GameObject getpooledobject()
    {
        for (i = 0; i < pooledobjects.Count; i++)
        {
            if (!pooledobjects[i].activeInHierarchy)
            {
                Debug.Log("spawn");
                return pooledobjects[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    public void pooladd(GameObject obj)
    {
        pooledobjects.Add(obj);
    }
}
