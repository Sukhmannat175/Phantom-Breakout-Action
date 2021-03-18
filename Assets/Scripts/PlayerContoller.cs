using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public GameObject blastSpawn, PowerBlastRight, PowerBlastLeft, PowerBlastUp, PowerBlastDown;
    public float fireRate;

    private float timer = 0;

    void Update()
    {
        Movement();
        Direction();
        Shooting();
    }

    void Movement()
    {
        float horiz, vert;

        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horiz, vert);
        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;

        float horizSpeed = horiz * speed;
        float vertSpeed = vert * speed;
        anim.SetFloat("Horizontal Speed", Mathf.Abs(horizSpeed));
        anim.SetFloat("Vertical Speed", vertSpeed);
    }

    void Direction()
    {
        Vector3 charecterScale = transform.localScale;
        Vector3 spawnPos = blastSpawn.transform.localPosition;
        
        if (Input.GetKey(KeyCode.D))
        {
            charecterScale.x = Mathf.Abs(charecterScale.x);
            spawnPos.x = 0.86f;
            spawnPos.y = -0.16f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            charecterScale.x = Mathf.Abs(charecterScale.x) * - 1;
            spawnPos.x = 0.861f;
            spawnPos.y = -0.16f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            spawnPos.x = 0;
            spawnPos.y = 1.5f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            spawnPos.x = 0;
            spawnPos.y = -1.5f;
        }
        transform.localScale = charecterScale;
        blastSpawn.transform.localPosition = spawnPos;
    }

    void Shooting()
    {
        if (Input.GetAxis("Fire1") > 0 && timer >= fireRate)
        {
            GameObject powerBlast;
            Vector3 spawnPos = blastSpawn.transform.localPosition;

            if (spawnPos.x == 0.86f)
            {
                powerBlast = GameObject.Instantiate(PowerBlastRight, blastSpawn.transform.position, blastSpawn.transform.rotation);
            }

            else if (spawnPos.x == 0.861f)
            {
                powerBlast = GameObject.Instantiate(PowerBlastLeft, blastSpawn.transform.position, blastSpawn.transform.rotation);
            }
            
            else if (spawnPos.y == 1.5f)
            {
                powerBlast = GameObject.Instantiate(PowerBlastUp, blastSpawn.transform.position, blastSpawn.transform.rotation);
            }

            else if (spawnPos.y == -1.5f)
            {
                powerBlast = GameObject.Instantiate(PowerBlastDown, blastSpawn.transform.position, blastSpawn.transform.rotation);
            }
            timer = 0;
        }
        timer += Time.deltaTime;


    }
}
