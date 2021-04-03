using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTriggerScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, player.transform.position.y - 55);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

}
