using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreTexto;
    int score = 0;

    void Start()
    {
        score = SessionManager.Instance.GetScore();
    }

    void Update()
    {
        score = SessionManager.Instance.GetScore();
        scoreTexto.text = score.ToString();
    }
    
    
}
