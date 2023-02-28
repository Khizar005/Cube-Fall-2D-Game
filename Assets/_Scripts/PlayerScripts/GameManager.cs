using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ResumePanel;
    public GameObject ActiveButonFalse;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        ResumePanel.SetActive(false);
        Time.timeScale = 1;
        ActiveButonFalse.SetActive(true);
    }


    public void RestartGame()
    {
        ResumePanel.SetActive(true);
        Time.timeScale = 0;
        ActiveButonFalse.SetActive(false);
    }
}
