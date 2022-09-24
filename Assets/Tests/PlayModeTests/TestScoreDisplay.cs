using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestScoreDisplay
    {
        GameObject _scoreDisplay;

        [SetUp]
        public void Setup()
        {
            _scoreDisplay = new GameObject();
            _scoreDisplay.AddComponent<ScoreDisplay>();
            _scoreDisplay.GetComponent<ScoreDisplay>().scoreText = _scoreDisplay.AddComponent<Text>();
        }

        [UnityTest]
        public IEnumerator TestScoreDisplayHappyPath()
        {
            yield return null;            
            float expected = Random.Range(0 + Random.value, ScoreDisplay.MaxScore);
            _scoreDisplay.GetComponent<ScoreDisplay>().Score = expected;

            yield return null;
            Assert.AreEqual(expected.ToString(), _scoreDisplay.GetComponent<ScoreDisplay>().scoreText.text);
        }

        [UnityTest]
        public IEnumerator TestScoreDisplayZero()
        {
            yield return null;
            float expected = 0f;
            _scoreDisplay.GetComponent<ScoreDisplay>().Score = expected;

            yield return null;
            Assert.AreEqual(expected.ToString(), _scoreDisplay.GetComponent<ScoreDisplay>().scoreText.text);
        }

        [UnityTest]
        public IEnumerator TestScoreDisplayBelowZero()
        {
            yield return null;
            _scoreDisplay.GetComponent<ScoreDisplay>().Score = Random.Range(0 + Random.value, ScoreDisplay.MaxScore) * -1;

            yield return null;
            Assert.AreEqual("0", _scoreDisplay.GetComponent<ScoreDisplay>().scoreText.text);
        }

        [UnityTest]
        public IEnumerator TestScoreDisplayInfinity()
        {
            yield return null;
            _scoreDisplay.GetComponent<ScoreDisplay>().Score = Mathf.Infinity;

            yield return null;
            Assert.AreEqual(ScoreDisplay.MaxScore.ToString(), _scoreDisplay.GetComponent<ScoreDisplay>().scoreText.text);
        }
    }
}
