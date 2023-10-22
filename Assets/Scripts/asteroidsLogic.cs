using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody stone;
    private float Rotating_speed;
    public float moving_speed = 80;
    void Start()
    {
        stone  = GetComponent<Rigidbody>();
        Rotating_speed = Random.Range(0,360);
        stone.AddTorque(0f, 0f, Rotating_speed, ForceMode.Acceleration);
        stone.AddForce(0f, 0f, -moving_speed);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Rotating_speed);
        
        //this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Rotating_speed);
    }
    private void OnTriggerEnter(Collider cube)
    {
        Debug.Log("enter");
        if (cube.gameObject.tag == "bullet")
        {
            Debug.Log("enter_deeper");
            Destroy(cube.gameObject);
            Destroy(this.gameObject);
        }
        if (cube.gameObject.tag == "boundary")
        {
            Destroy(this.gameObject);
        }
    }
}
