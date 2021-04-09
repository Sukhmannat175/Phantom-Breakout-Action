using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    
    public float speed, fireRate;
    public Animator anim;
    public GameObject blastSpawn, PowerBlastRight, PowerBlastLeft, PowerBlastUp, PowerBlastDown;
    public GameObject portal1, portal2;
    
    public float timer = 0, key = 0, sacrifices = 0;

    public int countCollision = 0;

    public AudioClip BackMusic;
    public AudioClip keyPickUp;
    public AudioClip portal;
    public AudioClip orb;
    public AudioClip powerUp;
    public AudioClip sacrificePickUp;

    

    public GameController gameControllerScript;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(BackMusic, transform.position);
    }
    void Update()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }

        if (gameControllerScript == null)
        {
            Debug.Log("Cannot find GameController script on GameController object");
        }

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
            spawnPos.x = 0.88f;
            spawnPos.y = -0.18f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            charecterScale.x = Mathf.Abs(charecterScale.x) * - 1;
            spawnPos.x = 0.881f;
            spawnPos.y = -0.16f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            spawnPos.x = 0;
            spawnPos.y = 2;
        }

        if (Input.GetKey(KeyCode.S))
        {
            spawnPos.x = 0;
            spawnPos.y = -2;
        }
        transform.localScale = charecterScale;
        blastSpawn.transform.localPosition = spawnPos;
    }

    void Shooting()
    {
        if (Input.GetAxis("Fire1") > 0 && timer >= fireRate)
        {            
            Vector3 spawnPos = blastSpawn.transform.localPosition;            
            
            if (spawnPos.x == 0.88f)
            {            
                Instantiate(PowerBlastRight, blastSpawn.transform.position, Quaternion.identity);                
            }

            else if (spawnPos.x == 0.881f)
            {
                Instantiate(PowerBlastLeft, blastSpawn.transform.position, Quaternion.identity);
            }

            else if (spawnPos.y == 2)
            {
                Instantiate(PowerBlastUp, blastSpawn.transform.position, Quaternion.identity);
            }

            else if (spawnPos.y == -2)
            {
                Instantiate(PowerBlastDown, blastSpawn.transform.position, Quaternion.identity);
            }            
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            key ++;
            AudioSource.PlayClipAtPoint(keyPickUp, transform.position);
            gameControllerScript.KeyGotten();
        }

        if (other.gameObject.CompareTag("Portal 1"))
        {
            speed = 3;
            Destroy(portal1.GetComponent<CircleCollider2D>());
            AudioSource.PlayClipAtPoint(portal, transform.position);          
            gameControllerScript.Portal1();                       
            gameControllerScript.BossFight();
        }

        if (other.gameObject.CompareTag("Portal 2"))
        {
            speed = 3;
            Destroy(portal2.GetComponent<CircleCollider2D>());
            AudioSource.PlayClipAtPoint(portal, transform.position);            
            gameControllerScript.Portal2();
            gameControllerScript.BossFight();
        }

        if (other.gameObject.CompareTag("Power Up"))
        {
            AudioSource.PlayClipAtPoint(powerUp, transform.position);
            fireRate = 0.5f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Health"))
        {
            AudioSource.PlayClipAtPoint(powerUp, transform.position);
            gameControllerScript.Health();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Shield"))
        {
            AudioSource.PlayClipAtPoint(powerUp, transform.position);
            gameControllerScript.Shield();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Sacrifice"))
        {
            speed = 1.5f;
            Time.timeScale = 1;
            sacrifices++;
            AudioSource.PlayClipAtPoint(sacrificePickUp, transform.position);            
            gameControllerScript.BackToMaze();
        }

        if (other.gameObject.CompareTag("Orb") && sacrifices == 2)     
        {
            
            AudioSource.PlayClipAtPoint(orb, transform.position);
            Destroy(other.gameObject);
            gameControllerScript.GameWin();
        }

        if (other.gameObject.CompareTag("Enemy Attack"))
        {
            gameControllerScript.LoseLife();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Open Door"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Closed Door") && key > 0)
        {
            Destroy(other.gameObject);
            key--; 
            gameControllerScript.KeyUsed();            
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            gameControllerScript.LoseLife();
        }
    }
}
