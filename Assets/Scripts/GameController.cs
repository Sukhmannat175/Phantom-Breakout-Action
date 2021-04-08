using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [Header("GamePlay")]
    public float startWait;
    public GameObject lights;
    public GameObject blackBoard;

    [Header("UI")]
    public Text sacrificeText;
    public Text lifeText;
    public Text keyText;
    public GameObject gameWinText;
    public GameObject gameOverText;
    public GameObject restartText;

    private int lives = 3;
    private bool restart = false;
    

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
