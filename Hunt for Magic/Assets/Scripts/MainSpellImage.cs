using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSpellImage : MonoBehaviour
{
    public Object _currentSpell;
    public GameObject _fire;
    public GameObject _wind;
    public GameObject _electricity;
    public GameObject _water;
    public GameObject _fireball;
    public GameObject _lightningbolt;
    public GameObject _chainlightning;
    public GameObject _icewall;
    public GameObject _oil;
    public GameObject _weaponArea;
    public GameObject _activity;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "MainSpell")
        {
            _currentSpell = _weaponArea.GetComponent<SpellBehaviour>()._spell0;

            if (SpellBehaviour._activeSlot == 0)
            {
                _activity.SetActive(true);
            }
            else
            {
                _activity.SetActive(false);
            }
        }
        else if (gameObject.name == "Spellslot1")
        {
            _currentSpell = _weaponArea.GetComponent<SpellBehaviour>()._spell1;

            if (SpellBehaviour._activeSlot == 1)
            {
                _activity.SetActive(true);
            }
            else
            {
                _activity.SetActive(false);
            }
        }
        else if (gameObject.name == "Spellslot2")
        {
            _currentSpell = _weaponArea.GetComponent<SpellBehaviour>()._spell2;

            if (SpellBehaviour._activeSlot == 2)
            {
                _activity.SetActive(true);
            }
            else
            {
                _activity.SetActive(false);
            }
        }

        if (_currentSpell.name == "Flamethrower_particle")
        {
            _fire.SetActive(true);
        }
        else
        {
            _fire.SetActive(false);
        }

        if (_currentSpell.name == "WindEffect")
        {
            _wind.SetActive(true);
        }
        else
        {
            _wind.SetActive(false);
        }

        if (_currentSpell.name == "Electricity")
        {
            _electricity.SetActive(true);
        }
        else
        {
            _electricity.SetActive(false);
        }

        if (_currentSpell.name == "Waterwave")
        {
            _water.SetActive(true);
        }
        else
        {
            _water.SetActive(false);
        }

        if (_currentSpell.name == "Fireball")
        {
            _fireball.SetActive(true);
        }
        else
        {
            _fireball.SetActive(false);
        }

        if (_currentSpell.name == "LightningBolt")
        {
            _lightningbolt.SetActive(true);
        }
        else
        {
            _lightningbolt.SetActive(false);
        }

        if (_currentSpell.name == "ChainLightning")
        {
            _chainlightning.SetActive(true);
        }
        else
        {
            _chainlightning.SetActive(false);
        }

        if (_currentSpell.name == "IceWallSpell")
        {
            _icewall.SetActive(true);
        }
        else
        {
            _icewall.SetActive(false);
        }

        if (_currentSpell.name == "OilSpell")
        {
            _oil.SetActive(true);
        }
        else
        {
            _oil.SetActive(false);
        }
    }
}
