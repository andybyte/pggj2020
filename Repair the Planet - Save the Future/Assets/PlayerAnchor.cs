using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnchor : MonoBehaviour
{

    public Transform tracking_x;
    public float track_buffer = 1.75f;

    // Start is called before the first frame update

    // Update is called once per frame  
    private void FixedUpdate() {
        transform.position = new Vector3(tracking_x.position.x-track_buffer, transform.position.y, transform.position.z);
    }
}
