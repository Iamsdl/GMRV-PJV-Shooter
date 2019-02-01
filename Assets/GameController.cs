using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static float difficulty;

    public List<GameObject> gameObjects;
    public GameObject mainMenu;

    public static float TerminalVelocity { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        TerminalVelocity = 20.0f;
        difficulty = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
        }

    }

    public void StartGame()
    {
        foreach (var item in gameObjects)
        {
            item.SetActive(true);
        }
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void SetDifficulty()
    {
        float diff;
        if (float.TryParse(GameObject.FindGameObjectWithTag("MainMenuDifficulty").GetComponent<Text>().text, out diff))
        {
            difficulty = diff;
        }
        else
        {
            difficulty = 1.0f;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
