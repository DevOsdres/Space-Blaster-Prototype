using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startPanel;

    void Start()
    {
        Time.timeScale = 0f; // Pausar el juego al inicio
        startPanel.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // Reanudar el juego
        startPanel.SetActive(false);
    }
}
