using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,Camera.main.transform.position.y - player.transform.position.y / 100 + 3 , transform.position.z);
    }
}
