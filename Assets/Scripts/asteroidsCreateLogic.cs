using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsCreateLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject create_point;
    public GameObject[] stones;

    void Start()
    {
        InvokeRepeating("Create_stone", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Create_stone()
    {
        int length  = stones.Length;
        float random_num = Random.Range(-3.0f, 3.0f);
        Vector3 place_create = new Vector3(create_point.transform.position.x+random_num, create_point.transform.position.y, create_point.transform.position.z);
        Instantiate(stones[Random.Range(0, length)], place_create, Quaternion.Euler(0, 0, 0));
    }
    
}
