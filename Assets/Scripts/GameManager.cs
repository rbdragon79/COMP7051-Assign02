using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Maze maze;
    private Maze thisMaze;
    public GameObject player;
    public GameObject enemy;
    public GameObject endPanel;
    private static bool gameEnd = false;

    // Use this for initialization
    private void Start()
    {
        endPanel = GameObject.FindGameObjectWithTag("Finish");
        endPanel.SetActive(false);
        BeginGame();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home) || Input.GetButton("Restart") /*|| Input.touches[0].tapCount == 2*/)
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        gameEnd = false;
        thisMaze = Instantiate(maze) as Maze;
        thisMaze.GenerateMaze();
        player.transform.position = new Vector3(9.5f, 0, -9.5f);
        enemy.transform.position = new Vector3(-7.5f, 0, 7.5f);
    }

    private void RestartGame()
    {
        
        if(gameEnd)
        {
            endPanel.SetActive(false);
        }        

        Destroy(thisMaze.gameObject);
        BeginGame();
    }

    public void EndGame()
    {
        endPanel.SetActive(true);
        gameEnd = true;
    }
}
