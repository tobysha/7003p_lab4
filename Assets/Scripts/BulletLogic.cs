using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 movement = new Vector3(0, 0, 10.0f);
    public float bulletspeed  = 500;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("destroy_bullet",3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(movement * bulletspeed * Time.fixedDeltaTime);

    }
    void destroy_bullet()
    {
        Destroy(this.gameObject);
    }
    
}
