using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepcontrol : MonoBehaviour
{
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end = new Vector3(-3f, -1.4f, 0);
    public float speed;
    [SerializeField] private float duration = 25f;
    [SerializeField] private float timetaken;
    [SerializeField] private Vector3 spawn;
    // Start is called before the first frame update

    public void OnEnable()
    {
        start = new Vector3(22.5f, 10.5f, 0);
    }
    void Start()
    {
        start = transform.position;
        //way = GameObject.FindGameObjectWithTag("point");
    }

    // Update is called once per frame
    void Update()
    {
        timetaken += Time.deltaTime;
        float percentage = timetaken / duration;
        transform.position = Vector3.MoveTowards(start, end, percentage);
        
        //        transform.position = Vector2.MoveTowards(transform.position, way.transform.position, movespeed * Time.deltaTime);
        //transform.position = Vector3.Lerp(start, end, percentage);
        if(transform.position == end)
        {
            transform.position = new Vector3(9f, 4.2f, 0);
            gameObject.SetActive(false);
            timetaken = 0;
            objectpool.instance.pooladd(this.gameObject);
        }
    }
}
