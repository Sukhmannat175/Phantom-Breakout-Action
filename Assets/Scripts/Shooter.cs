using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float speed;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f); 
    }
}
