using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour
{
    public float xSpeed, ySpeed;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
        string scene = SceneManager.GetActiveScene().name;

        if (scene == "Boss Fight")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2 * xSpeed, 2 * ySpeed);
        }
    }
}
