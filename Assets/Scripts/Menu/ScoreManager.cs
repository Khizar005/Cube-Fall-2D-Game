using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
  
    void Start()
    {
        currentScoreText.text = PlayerPrefs.GetString("CurretScore");
    }
}
