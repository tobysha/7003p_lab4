using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Player_Controller : MonoBehaviour
{
    private Vector2 movevalue;
    public int speed = 0;
    public float max_X, min_X;
    public float max_Z, min_Z;
    private Rigidbody rb;
    public float rotating_speed = 0;
    public float rotation_min = -30;
    public float rotation_max = 30;
    public GameObject bullet_prefab;
    public GameObject Fire_point;
    private float time_count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_X, max_X), 0.5f, Mathf.Clamp(transform.position.z, min_Z, max_Z));
        //rb.MoveRotation(Quaternion.Slerp(rb.rotation, target, Time.deltaTime * 7));

    }
    void OnMove(InputValue value)
    {
        movevalue = value.Get<Vector2>();

    }
    void OnFire()
    {
        if(time_count>=0.5)
        {
            time_count = 0;
            Instantiate(bullet_prefab, Fire_point.transform.position, Quaternion.Euler(90, 0, 0));

        }

    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movevalue.x, 0.5f, movevalue.y);
        //Debug.Log(movement * speed * Time.fixedDeltaTime);
        if(min_X <= transform.position.x|| transform.position.x <= max_X|| min_Z <= transform.position.z|| transform.position.z <= max_Z)
        {
            rb.AddForce(movement * speed * Time.fixedDeltaTime);
        }  
        float rotation = -rb.velocity.x * rotating_speed;
        rotation = Mathf.Clamp(rotation, rotation_min, rotation_max);
        Quaternion ratation = Quaternion.Euler(0f, 0f, rotation);

        this.gameObject.transform.rotation = ratation;
        time_count += Time.fixedDeltaTime;


    }
    
}
