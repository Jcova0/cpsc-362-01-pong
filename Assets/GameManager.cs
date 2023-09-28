using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;

    public static int PlayerScore2 = 0;

    public static Vector2 Player1Pos;
    public static Vector2 Player2Pos;
    public GUISkin layout;
    GameObject _theBall;
    
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
      
    }
    public static void Score(String goalID)
    {
        if(goalID == "RightGoal")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        
        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "Restart"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            Player1Pos = GameObject.FindGameObjectWithTag("Player1").transform.position = new Vector2(-7.5f, 0);
            Player2Pos = GameObject.FindGameObjectWithTag("Player2").transform.position = new Vector2(7.5f, 0);
            _theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            
        }

        if (PlayerScore1 == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
        }
        else if (PlayerScore2 == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            _theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}

