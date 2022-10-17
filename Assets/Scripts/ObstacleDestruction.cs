using UnityEngine;

public class ObstacleDestruction : MonoBehaviour, IDamageable, IDurable
{
    private float _maxDurability;
    private float _currentDurability;

    public float MaxDurability { 
        get {
            if( _maxDurability < 1)
            {
                _maxDurability = 1;
            }
            if(_maxDurability < _currentDurability)
            {
                _maxDurability = _currentDurability;
            }
            return _maxDurability;
        } 
    }

    public float CurrentDurability
    {
        get
        {
            if( _currentDurability < 0) {
                _currentDurability = 0;
            }
            if(_currentDurability > _maxDurability)
            {
                _currentDurability = _maxDurability;
            }
            return _currentDurability;
        }

        set
        {
            if(value < 0)
            {
                _currentDurability = 0;
                return;
            }

            if (value > _maxDurability)
            {
                _currentDurability = _maxDurability;
                return;
            }

            _currentDurability = value;
        }
    }

    public void ReceiveDamage(float damage)
    {
        CurrentDurability -= damage;
        if(CurrentDurability <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _maxDurability = Constants.Obstacle.InitialMaxDurability;
        _currentDurability = _maxDurability;
    }
}
