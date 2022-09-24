using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private float _maximum;
    [SerializeField]
    private float _current;
    public Image mask;

    private const float DefaultMaximum = 10f;
    private const float Minimum = 0f;

    public float Current
    {
        get { return _current; }
        set
        {
            if (value < Minimum)
            {
                _current = Minimum;
                return;
            }
            if (value > _maximum)
            {
                _current = _maximum;
                return;
            }

            _current = value;
        }
    }
    public float Maximum { get { return _maximum; } set { _maximum = value; } }

    private void Start()
    {
        _maximum = DefaultMaximum;
        _current = _maximum;
    }

    private void Update()
    {
        SetFillAmount();
    }

    private void SetFillAmount()
    {
        float progress = _current / _maximum;
        mask.fillAmount = progress;
    }
}

