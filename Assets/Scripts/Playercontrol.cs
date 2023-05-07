using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumptime;
    [SerializeField] private float jumpforce;
    [SerializeField] private float fallmultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        while (jumptime > 0)
        {
            jumpstart();
            jumptime -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y <= 0)
        {
            rb.velocity = Vector2.down * fallmultiplier;
            //Physics.gravity.y = -4f;
        }
    }

    void jumpstart()
    {
        rb.velocity = Vector2.up * jumpforce;
        //rb.AddForce(Vector2.up * jumpforce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //jumptime = 1.2f;
        jumpstart();
    }
}
