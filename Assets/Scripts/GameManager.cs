using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Maze maze;
    private Maze thisMaze;
    public int timer;
    public Text timerText;
    public Text survivalTimeText;
    public GameObject player;
    public GameObject enemy;
    public GameObject endPanel;
    public Toggle ghostToggle;
    private static bool gameEnd = false;
    public Light sun;
    

    // Use this for initialization
    private void Start()
    {
        timer = 0;
        endPanel = GameObject.FindGameObjectWithTag("Finish");
        endPanel.SetActive(false);
        sun.enabled = !sun.enabled;
        BeginGame();
    }

    // Update is called once per frame
    private void Update()
    {
        timerText.text = timer.ToString();
        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown("joystick button 7"))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        gameEnd = false;
        thisMaze = Instantiate(maze) as Maze;
        thisMaze.GenerateMaze();
        ghostToggle.isOn = false;
        player.transform.position = new Vector3(9.5f, 0, -9.5f);
        enemy.transform.position = new Vector3(-7.5f, 0, 7.5f);
        timer = 0;
        StartCoroutine("SurvivalTime");
    }

    private void RestartGame()
    {
        
        if(gameEnd)
        {
            endPanel.SetActive(false);
        } else
        {
            StopCoroutine("SurvivalTime");
        }        
        Destroy(thisMaze.gameObject);
        BeginGame();
    }

    public void EndGame()
    {
        StopCoroutine("SurvivalTime");
        endPanel.SetActive(true);
        survivalTimeText.text = "You were caught\n"
            + "You survived " + timer + " seconds\n"
            + "Try Again";
        gameEnd = true;
    }

    // Increase the timer by 1 each second passed
    IEnumerator SurvivalTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer++;
        }
    }
}
