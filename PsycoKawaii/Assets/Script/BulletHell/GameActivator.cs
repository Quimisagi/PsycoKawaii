using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActivator : MonoBehaviour
{
    public delegate void GameActivatorDelegate();
    public static event GameActivatorDelegate startGame;
    // Start is called before the first frame update
    public void StartGame()
    {
        gameObject.SetActive(false);
        startGame();
    }
}
