using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public GameObject PowerBlast, blastSpawn;
    public float fireRate;

    private float timer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moving Player

        Movement();

        float horiz, vert;

        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horiz, vert);
        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;

        float horizSpeed = horiz * speed;
        float vertSpeed = vert * speed;
        anim.SetFloat("Horizontal Speed", Mathf.Abs(horizSpeed));
        anim.SetFloat("Vertical Speed", Mathf.Abs(vertSpeed));

        // Shooting
        
        if(Input.GetAxis("Fire1")>0 && timer>=fireRate)
        {
            GameObject powerBlast;
            powerBlast = GameObject.Instantiate(PowerBlast, blastSpawn.transform.position, blastSpawn.transform.rotation);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void Movement()
    {
        Vector3 charecterScale = transform.localScale;
        
        if (Input.GetKey(KeyCode.D))
        {
            charecterScale.x = Mathf.Abs(charecterScale.x);
        }

        if (Input.GetKey(KeyCode.A))
        {
            charecterScale.x = Mathf.Abs(charecterScale.x) * - 1;
        }
        transform.localScale = charecterScale;
    }
}
