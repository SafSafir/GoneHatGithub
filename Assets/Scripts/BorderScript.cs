using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = new Vector2(transform.position.x, player.transform.position.y-60);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

}