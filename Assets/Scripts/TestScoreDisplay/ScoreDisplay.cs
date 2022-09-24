using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    private float _score;

    public float Score {
        get { return _score; }
        set { 
            if(value > MaxScore)
            {
                _score = MaxScore;
                return;
            }
            if(value < 0)
            {
                _score = 0;
                return;
            }
            _score = value; 
        }
    }

    public const float MaxScore = 1000000;

    private void SetScoreText()
    {
        scoreText.text = _score.ToString();
    }

    private void Start()
    {
        _score = 0;
        SetScoreText();
    }

    private void Update()
    {
        SetScoreText();
    }
}
