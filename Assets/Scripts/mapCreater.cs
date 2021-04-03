using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreater : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject player;
    public GameObject balloon;
    public GameObject[] Patterns;
    
    private int wallLength = 15;
    private float randomBalloonX = 0;


    private void Awake()
    {
    }
    void Start()
    {
    }


    void Update()
    {
        
        randomBalloonX = UnityEngine.Random.Range(-2f, 2f); 
        if (player.transform.position.y > wallLength)
        {
            if(player.transform.position.y > 45)
            {
                Instantiate(balloon, new Vector3(randomBalloonX, player.transform.position.y - 7, balloon.transform.position.z), Quaternion.identity);
            }

            Instantiate(leftWall, new Vector3(leftWall.transform.position.x, wallLength + 30, leftWall.transform.position.z), Quaternion.identity);
            
            Instantiate(rightWall, new Vector3(rightWall.transform.position.x, wallLength + 30, rightWall.transform.position.z), Quaternion.identity);

            Instantiate(Patterns[UnityEngine.Random.Range(0, Patterns.Length)], new Vector3(0, wallLength + 15, rightWall.transform.position.z), Quaternion.identity);

            wallLength += 30;
        }

        
    }
    
}
