using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestTranslator
    {
        GameObject _gameObject;
        Rigidbody2D _rb;
        Translator _translator;
        Vector3 _oldPosition;

        [SetUp]
        public void Setup()
        {
            _gameObject = new GameObject();
            _rb = _gameObject.AddComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _translator = _gameObject.AddComponent<Translator>();
            _oldPosition = _gameObject.transform.position;
        }

        [UnityTest]
        public IEnumerator GivenZeroMovementVectorTheObjectStaysInPlace()
        {
            yield return null;
            _translator.Move(Vector2.zero);

            yield return new WaitForSeconds(1f);
            Assert.AreEqual(_oldPosition, _gameObject.transform.position);
        }

        [UnityTest]
        public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesAsExpected()
        {
            yield return null;
            _translator.Move(Vector2.right);

            yield return new WaitForSeconds(1f);
            Assert.AreEqual(_oldPosition.y, _gameObject.transform.position.y);
            Assert.IsTrue(
                Mathf.Approximately(1f, _gameObject.transform.position.x), 
                "transform.position.x is not 1f as expected");
        }

        [UnityTest]
        public IEnumerator GivenDiagonalMovementVectorTheGameObjectMovesAsExpected()
        {
            yield return null;
            _translator.Move(new Vector2(2f, 2f));

            yield return new WaitForSeconds(1f);
            Assert.IsTrue(
                Mathf.Approximately(2f, _gameObject.transform.position.y),
                "transform.position.y is not 1f as expected");
            Assert.IsTrue(
                Mathf.Approximately(2f, _gameObject.transform.position.x),
                "transform.position.x is not 1f as expected");
        }
    }
}
