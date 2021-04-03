using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFlyingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up*3;
    }
}
