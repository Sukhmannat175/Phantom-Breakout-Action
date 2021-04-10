using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject explosion;
    public GameObject sacrifice;
    public GameObject lights;
    public AudioClip Audiopart;
    public AudioClip deathSound;   

    public int enemyHP = 2;
    public GameController gameControllerScript;

    void Update()
    {
        if (Time.timeScale == 0)
        {
            GetComponent<AudioSource>().Stop();
            lights.SetActive(false);
        }
    }

    //other is powerBlast
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PowerBlast"))
        {          
            enemyHP -= 1;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(Audiopart, transform.position);

            if(enemyHP == 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Instantiate(sacrifice, transform.position, Quaternion.identity);                
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
