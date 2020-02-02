using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingTide : MonoBehaviour
{

    public float position_y;
    public float increment_y;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RiseTide", 3.0f, 1.0f);
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        position_y = transform.position.y;   
    }

    void RiseTide() {
        transform.position = new Vector3(transform.position.x, transform.position.y + increment_y, transform.position.z);
    }
}
