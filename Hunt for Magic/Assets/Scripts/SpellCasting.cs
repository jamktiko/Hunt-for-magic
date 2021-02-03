using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField]
    private GameObject _spellPrefab;

    [SerializeField]
    private Transform _castingPoint;

    [SerializeField]
    private float _throwForce = 20.0f;

    private bool _spellCooldown;

    [SerializeField]
    private float _spellInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            if (_spellCooldown)
            {
                return;
            }

            GameObject spell = Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
            spell.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _throwForce, ForceMode.Impulse);

            _spellCooldown = true;

            Invoke("EndCooldown", _spellInterval);
        }
    }

    public void EndCooldown()
    {
        _spellCooldown = false;
    }
}
