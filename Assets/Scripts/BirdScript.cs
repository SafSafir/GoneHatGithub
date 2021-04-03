using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BirdScript : MonoBehaviour
{
    float leftLimit = -2.2f;
    float rightLimit = 2.2f;
    [SerializeField] int speed = 2;
    private int birdFallSpeed = 0;
    private bool birdFalling;

    Vector2 birdvelocity;

    Rigidbody2D phy;
    SpriteRenderer rd;

    public GameObject player;

    private void Awake()
    {
        birdFalling = false;
        phy = GetComponent<Rigidbody2D>();
        rd = GetComponent<SpriteRenderer>();
        birdvelocity = new Vector2(speed, 0);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        phy.velocity = birdvelocity;
        if(transform.position.x > rightLimit && !birdFalling)
        {
            rd.flipX = true;
            birdvelocity = new Vector2(-speed,birdFallSpeed);
            
        }
        else if(transform.position.x < leftLimit && !birdFalling)
        {
            rd.flipX = false;
            birdvelocity = new Vector2(speed, birdFallSpeed);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            birdFalling = true;
            birdvelocity = new Vector2(0, -3);
            transform.Rotate(new Vector3(0, 0, -120));
        }
    }

}
