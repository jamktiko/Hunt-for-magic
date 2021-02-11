using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour  // Tämä scripti liitetään pelaajaan
{
    [SerializeField]
    private GameObject _spellPrefab;

    private Transform _castingPoint;

    [SerializeField]
    private float _throwForce = 20.0f;

    private bool _spellCooldown;

    [SerializeField]
    private float _spellInterval = 1f;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_spellPrefab.name == "WindSpellPrefab")
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

            if (_spellPrefab.name == "Flamethrower_particle")
            {
                _player.GetComponent<EnergySystem>().ReduceEnergy(1f);

                if (_player.GetComponent<EnergySystem>()._currentEnergy < 5)
                {
                    return;
                }

                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
            }

            if (_spellPrefab.name == "WaterWavePrefab")
            {
                WaterSpell.SpawnSpell(_spellPrefab, _castingPoint, _throwForce);

                _spellCooldown = true;

                Invoke("Endcooldown", _spellInterval);
            }

        }
    }

    public void EndCooldown()
    {
        _spellCooldown = false;
    }
}
