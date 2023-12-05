using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
     public void OnPlayButton()
     {
          SceneManager.LoadScene("LevelOne");
     }

     public void OnLevelTwoButton()
     {
          SceneManager.LoadScene("LevelTwo");
     }

     public void OnLevelThreeButton()
     {
          SceneManager.LoadScene("LevelThree");
     }

     public void OnQuitButton()
     {
          #if UNITY_STANDALONE
               Application.Quit();
          #endif
          #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
          #endif
     }
}
