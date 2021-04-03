using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HatScript : MonoBehaviour
{
    public float hatSpeed;
    

    void Update()
    {
        transform.DOMoveY(50, 50);
        transform.DOShakePosition(10, 0.2f, 1, 1);
    }
}
