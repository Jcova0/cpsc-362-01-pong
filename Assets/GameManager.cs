using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;

    public static int PlayerScore2 = 0;

    public static int score_multi = 1; 

    public int winScore = 3;
    public WallSpawner wallSpawner;
    public GameObject powerUp;
    public static Vector2 Player1Pos;
    public static Vector2 Player2Pos;
    public GUISkin layout;
    public static bool isScoreMulti = false;
    public GUIStyle style;
    GameObject _theBall;

    private static string lastToHit;
    // Start is called before the first frame update
    void Start()
    {
        _theBall = GameObject.FindGameObjectWithTag("Ball");
        Player1Pos = GameObject.FindGameObjectWithTag("Player1").transform.position;
        Player2Pos = GameObject.FindGameObjectWithTag("Player2").transform.position;
    }

    
    // Update is called once per frame
    void Update()
    {
        Player1Pos = GameObject.FindGameObjectWithTag("Player1").transform.position;
        Player2Pos = GameObject.FindGameObjectWithTag("Player2").transform.position;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            PlayerScore1 = 0;
            PlayerScore2 = 0;
        }
    }

    public void apply_score_multi (int multi, string whoHit) {
        isScoreMulti = true;
        score_multi = multi;
        whoHit = lastToHit;
    }

    public static void Score(String goalID)
    {
        if(goalID == "RightGoal")
        {
            if(isScoreMulti){
                
                PlayerScore1 += score_multi;
                isScoreMulti = false;
            }
            else{
                PlayerScore1 += 1;
            }
        }
        else
        {
            if(isScoreMulti && lastToHit == "Player2"){
                PlayerScore2 += score_multi;
                isScoreMulti = false;
            }
            else{
                PlayerScore2 += 1;
            }
        }
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1, style);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2, style);
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            Player1Pos = GameObject.FindGameObjectWithTag("Player1").transform.position = new Vector2(-7.5f, 0);
            Player2Pos = GameObject.FindGameObjectWithTag("Player2").transform.position = new Vector2(7.5f, 0);
            _theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            wallSpawner.ResetGame();
        }

        if (PlayerScore1 >= winScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 100, 100), "PLAYER ONE WINS", style);
            _theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            GUI.Label(new Rect(Screen.width / 2 - 500, 300, 100, 100), "Press 'ESC' to return to the main menu or Press 'R' to play again!", style);
        }
        else if (PlayerScore2 >= winScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 100, 100), "PLAYER TWO WINS");
            _theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            GUI.Label(new Rect(Screen.width / 2 - 500, 300, 100, 100), "Press 'ESC' to return to the main menu or Press 'R' to play again!", style);
        }
    }
}

