using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [Header("GamePlay")]
    public GameObject lights;    

    [Header("UI")]
    public Text sacrificeText;
    public Text lifeText;
    public Text keyText;
    public GameObject gameWinText;
    public GameObject gameOverText;    
    public GameObject exitText;

    [Header("Scene")]
    public GameObject mainCam;
    public GameObject followCam;
    public GameObject enemies, waypoints, entities;
    public GameObject border, maze, background;
    public GameObject character;
    public GameObject canvas, eventSystem;

    [Header("Attack")]
    public GameObject PowerBlastRight;
    public GameObject PowerBlastLeft;
    public GameObject PowerBlastUp;
    public GameObject PowerBlastDown;


    private int lives = 3, armour = 2, keys = 0, sacrifices = 0;        
    private bool shield = false;
    private bool portal1 = false, portal2 = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            GameOver(); 
        }  

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoseLife()
    {
        if (shield == false)
        {
            lives--;
            lifeText.text = "Lives:" + lives;
        }

        if (shield)
        {
            armour--;
            lifeText.text = "Lives:" + lives + "+" + armour;            
        }

        if (armour == 0)
        {
            shield = false;
            lifeText.text = "Lives:" + lives;
        }
    }

    public void KeyGotten()
    {
        keys++;
        keyText.text = "Keys:" + keys;
    }

    public void KeyUsed()
    {
        keys--;
        keyText.text = "Keys:" + keys;
    }

    public void Sacrifice()
    {
        sacrifices++;
        sacrificeText.text = "Sacrifices:" + sacrifices;
    }

    public void Health()
    {
        if (shield == false)
        {
            lives = 3;
            lifeText.text = "Lives:" + lives;
        }

        if (shield)
        {
            lives = 3;
            lifeText.text = "Lives:" + lives + "+" + armour;
        }
    }

    public void Shield()
    {
        shield = true;
        lifeText.text = "Lives:" + lives + "+" + armour;
    }

    public void Portal1()
    {
        portal1 = true;
    }

    public void Portal2()
    {
        portal2 = true;
    }

    public void BossFight()
    {
        followCam.SetActive(false);
        enemies.SetActive(false);
        waypoints.SetActive(false);
        entities.SetActive(false);
        border.SetActive(false);
        maze.SetActive(false);
        background.SetActive(false);
        lights.SetActive(false);

        mainCam.GetComponent<Camera>().orthographicSize = 5;
        Vector3 camPos = mainCam.transform.localPosition;
        camPos.x = 0;
        camPos.y = 0;
        mainCam.transform.localPosition = camPos;

        Vector3 charPos = character.transform.localPosition;
        charPos.x = -6.3f;
        charPos.y = 0;
        character.transform.localPosition = charPos;

        Vector3 scale = character.transform.localScale;
        scale.x = 0.5f;
        scale.y = 0.5f;
        scale.z = 0.5f;
        character.transform.localScale = scale;

        Vector3 scale1 = PowerBlastLeft.transform.localScale;
        scale1.x = 1;
        scale1.y = 1;
        scale1.z = 1;
        PowerBlastLeft.transform.localScale = scale1;

        Vector3 scale2 = PowerBlastRight.transform.localScale;
        scale2.x = 1;
        scale2.y = 1;
        scale2.z = 1;
        PowerBlastRight.transform.localScale = scale2;

        Vector3 scale3 = PowerBlastDown.transform.localScale;
        scale3.x = 1;
        scale3.y = 1;
        scale3.z = 1;
        PowerBlastDown.transform.localScale = scale3;

        Vector3 scale4 = PowerBlastUp.transform.localScale;
        scale4.x = 1;
        scale4.y = 1;
        scale4.z = 1;
        PowerBlastUp.transform.localScale = scale4;

        SceneManager.LoadScene("Boss Fight #1");        
    }

    public void BackToMaze()
    {
        followCam.SetActive(true);
        enemies.SetActive(true);
        waypoints.SetActive(true);
        entities.SetActive(true);
        border.SetActive(true);
        maze.SetActive(true);
        background.SetActive(true);
        lights.SetActive(true);        

        mainCam.GetComponent<Camera>().orthographicSize = 1.5f;
        Vector3 camPos = mainCam.transform.localPosition;
        camPos.x = 6.29f;
        camPos.y = 3.5f;
        mainCam.transform.localPosition = camPos;

        if (portal1)
        {
            Vector3 charPos = character.transform.localPosition;
            charPos.x = -5.5f;
            charPos.y = -1.4f;
            character.transform.localPosition = charPos;
            portal1 = false;
        }

        if (portal2)
        {
            Vector3 charPos = character.transform.localPosition;
            charPos.x = 2.2f;
            charPos.y = -1.67f;
            character.transform.localPosition = charPos;
            portal2 = false;
        }

        Vector3 scale = character.transform.localScale;
        scale.x = 0.2f;
        scale.y = 0.2f;
        scale.z = 0.2f;
        character.transform.localScale = scale;

        Vector3 scale1 = PowerBlastLeft.transform.localScale;
        scale1.x = 0.25f;
        scale1.y = 0.25f;
        scale1.z = 0.25f;
        PowerBlastLeft.transform.localScale = scale1;

        Vector3 scale2 = PowerBlastRight.transform.localScale;
        scale2.x = 0.25f;
        scale2.y = 0.25f;
        scale2.z = 0.25f;
        PowerBlastRight.transform.localScale = scale2;

        Vector3 scale3 = PowerBlastDown.transform.localScale;
        scale3.x = 0.25f;
        scale3.y = 0.25f;
        scale3.z = 0.25f;
        PowerBlastDown.transform.localScale = scale3;

        Vector3 scale4 = PowerBlastUp.transform.localScale;
        scale4.x = 0.25f;
        scale4.y = 0.25f;
        scale4.z = 0.25f;
        PowerBlastUp.GetComponent<Transform>().localScale = scale4;
        
        SceneManager.LoadScene("The Labyrinth 2");
        Sacrifice();
    }

    public void ResetScene()
    {
        gameOverText.SetActive(false);
        exitText.SetActive(false);
        followCam.SetActive(true);
        enemies.SetActive(true);
        waypoints.SetActive(true);
        entities.SetActive(true);
        border.SetActive(true);
        maze.SetActive(true);
        background.SetActive(true);
        lights.SetActive(true);

        sacrificeText.text = "Sacrifices:" + sacrifices;
        keyText.text = "Keys:" + keys;
        lifeText.text = "Lives:" + lives;

        mainCam.GetComponent<Camera>().orthographicSize = 1.5f;
        Vector3 camPos = mainCam.transform.localPosition;
        camPos.x = 6.29f;
        camPos.y = 3.5f;
        mainCam.transform.localPosition = camPos;

        Vector3 charPos = character.transform.localPosition;
        charPos.x = -6.29f;
        charPos.y = 3.5f;
        character.transform.localPosition = charPos;

        Vector3 scale = character.transform.localScale;
        scale.x = 0.2f;
        scale.y = 0.2f;
        scale.z = 0.2f;
        character.transform.localScale = scale;

        Vector3 scale1 = PowerBlastLeft.transform.localScale;
        scale1.x = 0.25f;
        scale1.y = 0.25f;
        scale1.z = 0.25f;
        PowerBlastLeft.transform.localScale = scale1;

        Vector3 scale2 = PowerBlastRight.transform.localScale;
        scale2.x = 0.25f;
        scale2.y = 0.25f;
        scale2.z = 0.25f;
        PowerBlastRight.transform.localScale = scale2;

        Vector3 scale3 = PowerBlastDown.transform.localScale;
        scale3.x = 0.25f;
        scale3.y = 0.25f;
        scale3.z = 0.25f;
        PowerBlastDown.transform.localScale = scale3;

        Vector3 scale4 = PowerBlastUp.transform.localScale;
        scale4.x = 0.25f;
        scale4.y = 0.25f;
        scale4.z = 0.25f;
        PowerBlastUp.transform.localScale = scale4;

        SceneManager.LoadScene("The Labyrinth 2");
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        exitText.SetActive(true);
        lights.SetActive(false);
        sacrificeText.text = "";
        keyText.text = "";
        lifeText.text = "";
        Time.timeScale = 0;
    }
    public void GameWin()
    {
        gameWinText.SetActive(true);
        exitText.SetActive(true);
        Time.timeScale = 0;
    }
}
