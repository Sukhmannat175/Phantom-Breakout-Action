using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    public GameObject explosion;    
    public AudioClip Audiopart;
    public AudioClip Audiofull;

    public int enemyHP = 2;
    public GameController gameControllerScript;

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
                GameObject effectFull = Instantiate(explosion, transform.position, Quaternion.identity);                
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(Audiofull, transform.position);
            }
        }
    }
}
