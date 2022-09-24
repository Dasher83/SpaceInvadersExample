using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public const float MaxScore = 1000000;

    [SerializeField]
    [Range(0, MaxScore)]
    private float _score;

    public float Score
    {
        get { return _score; }
        set
        {
            if (value > MaxScore)
            {
                _score = MaxScore;
                return;
            }
            if (value < 0)
            {
                _score = 0;
                return;
            }
            _score = value;
        }
    }

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