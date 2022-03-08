using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonResetScript : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public GameManager gameManager;
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        gameManager.gameState = true;
    }
   
}
