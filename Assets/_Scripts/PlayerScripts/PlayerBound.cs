using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour
{
    public float min_X = -2.04f , max_X = 2.04f;

    private void Update()
    {
        CheckForBound();
    }

    private void CheckForBound()
    {
        Vector2 temp = transform.position;

        if(temp.x > max_X)
        {
            temp.x = max_X;
        }

        if(temp.x < min_X)
        {
            temp.x = min_X;
        }

        transform.position = temp;
    }
    
}
