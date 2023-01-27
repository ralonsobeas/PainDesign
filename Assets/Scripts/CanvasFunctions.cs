using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFunctions : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private MoveController moveController;
    [SerializeField] private GameObject[] listaActivablesPausa,listaDesactivablesPausa;
    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        moveController.enabled = false;
        for (int i = 0; i < listaActivablesPausa.Length; i++)
        {
            listaActivablesPausa[i].SetActive(true);
        }
        for (int i = 0; i < listaDesactivablesPausa.Length; i++)
        {
            listaDesactivablesPausa[i].SetActive(false);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        moveController.enabled = true;
        for (int i = 0; i < listaActivablesPausa.Length; i++)
        {
            listaActivablesPausa[i].SetActive(false);
        }
        for (int i = 0; i < listaDesactivablesPausa.Length; i++)
        {
            listaDesactivablesPausa[i].SetActive(true);
        }
    }
    public void TogglePause()
    {
        if (pausePanel.activeSelf) Resume();
        else Pause();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
