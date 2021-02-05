using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    [SerializeField]
    public float _maxEnergy = 100f;

    [SerializeField]
    public float _currentEnergy;


    // Start is called before the first frame update
    void Start()
    {
        _currentEnergy = _maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentEnergy < _maxEnergy)
        {
            _currentEnergy = Mathf.MoveTowards(_currentEnergy / _maxEnergy, 1f, Time.deltaTime * 0.1f) * _maxEnergy;
        }

        if (_currentEnergy < 0)
        {
            _currentEnergy = 0;
        }
    }

    public void ReduceEnergy(float energy)
    {
        if (energy <= _currentEnergy)
        {
            _currentEnergy -= energy;
        }
    }
}
