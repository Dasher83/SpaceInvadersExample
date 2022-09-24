using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestHealthBar
    {
        GameObject _healthBar;

        [SetUp]
        public void Setup()
        {
            _healthBar = new GameObject();
            _healthBar.AddComponent<HealthBar>();
            _healthBar.GetComponent<HealthBar>().mask = _healthBar.AddComponent<Image>();
            _healthBar.GetComponent<Image>().type = Image.Type.Filled;
        }

        [UnityTest]
        public IEnumerator TestHappyPath()
        {
            yield return null;

            float _lives = Random.Range(1f, _healthBar.GetComponent<HealthBar>().Maximum - 1f);
            _healthBar.GetComponent<HealthBar>().Current = _lives;
            yield return null;

            float expectedFilled = _lives / _healthBar.GetComponent<HealthBar>().Maximum;
            Assert.IsTrue(
                Mathf.Approximately(expectedFilled, _healthBar.GetComponent<HealthBar>().mask.fillAmount),
                $"Expected: {expectedFilled}. But instead was: {_healthBar.GetComponent<HealthBar>().mask.fillAmount}");
        }

        [UnityTest]
        public IEnumerator TestExactlyMinimumCase()
        {
            yield return null;

            float _lives = 0f;
            _healthBar.GetComponent<HealthBar>().Current = _lives;
            yield return null;

            float expectedFilled = 0f;
            Assert.IsTrue(
                expectedFilled == _healthBar.GetComponent<HealthBar>().mask.fillAmount,
                $"Expected: {expectedFilled}. But instead was: {_healthBar.GetComponent<HealthBar>().mask.fillAmount}");
        }

        [UnityTest]
        public IEnumerator TestExactlyMaximumCase()
        {
            yield return null;

            float newMaximum = 8f;
            _healthBar.GetComponent<HealthBar>().Maximum = newMaximum;
            _healthBar.GetComponent<HealthBar>().Current = newMaximum;
            yield return null;

            float expectedFilled = 1f;
            Assert.IsTrue(
                expectedFilled == _healthBar.GetComponent<HealthBar>().mask.fillAmount,
                $"Expected: {expectedFilled}. But instead was: {_healthBar.GetComponent<HealthBar>().mask.fillAmount}");
        }

        [UnityTest]
        public IEnumerator TestBelowMinimumCase()
        {
            yield return null;

            float _lives = -100f;
            _healthBar.GetComponent<HealthBar>().Current = _lives;
            yield return null;

            float expected = 0f;
            Assert.IsTrue(expected == _healthBar.GetComponent<HealthBar>().Current,
                $"Expected: {expected}. But instead was: {_healthBar.GetComponent<HealthBar>().Current}");
            Assert.IsTrue(expected == _healthBar.GetComponent<HealthBar>().mask.fillAmount,
                $"Expected: {expected}. But instead was: {_healthBar.GetComponent<HealthBar>().mask.fillAmount}");
        }

        [UnityTest]
        public IEnumerator TestAboveMaximumCase()
        {
            yield return null;

            float _lives = _healthBar.GetComponent<HealthBar>().Maximum * Random.Range(1, 11) + 1;
            _healthBar.GetComponent<HealthBar>().Current = _lives;
            yield return null;

            float expected = _healthBar.GetComponent<HealthBar>().Maximum;
            Assert.IsTrue(expected == _healthBar.GetComponent<HealthBar>().Current,
                $"Expected: {expected}. But instead was: {_healthBar.GetComponent<HealthBar>().Current}");
            expected = 1f;
            Assert.IsTrue(expected == _healthBar.GetComponent<HealthBar>().mask.fillAmount,
                $"Expected: {expected}. But instead was: {_healthBar.GetComponent<HealthBar>().mask.fillAmount}");
        }
    }
}
