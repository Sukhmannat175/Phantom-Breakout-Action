using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [Header("GamePlay")]
    public float startWait;    
    public GameObject blackBoard;

    [Header("UI")]
    public GameObject sacrificeText;
    public GameObject lifeText;
    public GameObject keyText;
    public GameObject introOrbText;
    public GameObject introSacrificeText;
    public GameObject introPortalText;
    public GameObject introDoorText;
    public GameObject introKeyText;
    public GameObject continueText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startGame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("The Labyrinth");
        }
    }
    IEnumerator startGame()
    {
        yield return new WaitForSeconds(startWait);
        introOrbText.SetActive(true);        

        yield return new WaitForSeconds(startWait);
        introSacrificeText.SetActive(true);
        sacrificeText.SetActive(true);

        yield return new WaitForSeconds(startWait);
        introPortalText.SetActive(true);

        yield return new WaitForSeconds(startWait);
        introDoorText.SetActive(true);

        yield return new WaitForSeconds(startWait);
        introKeyText.SetActive(true);
        keyText.SetActive(true);
        continueText.SetActive(true);
    }              
}
