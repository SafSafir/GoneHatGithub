using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBalloonScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, player.transform.position.y + 30);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "balloon")
            Destroy(collision.gameObject);
    }
}
