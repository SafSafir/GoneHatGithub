using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOptimizer : MonoBehaviour
{
    public GameObject rightTransform;
    public GameObject leftTransform;
    public GameObject player;

    private void Awake()
    {
        rightTransform.transform.position = new Vector2(rightTransform.transform.position.x, player.transform.position.y);
        leftTransform.transform.position = new Vector2(leftTransform.transform.position.x, player.transform.position.y);
    }
    void Start()
    {
        
    }

    void Update()
    {
        rightTransform.transform.position = new Vector2(rightTransform.transform.position.x, player.transform.position.y);
        leftTransform.transform.position = new Vector2(leftTransform.transform.position.x, player.transform.position.y);
    }
}
