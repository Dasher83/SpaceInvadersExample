using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    [SerializeField]
    [Range(0, Constants.ScoreDisplay.MaxScore)]
    private float _score;

    public float Score
    {
        get { return _score; }
        set
        {
            if (value > Constants.ScoreDisplay.MaxScore)
            {
                _score = Constants.ScoreDisplay.MaxScore;
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