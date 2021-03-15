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
    public GameObject _chainlightning;


    // Start is called before the first frame update
    void Start()
    {
        _currentSpell = GameObject.Find("PlayerCharacter").GetComponent<SpellCasting>()._spellPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpell = GameObject.Find("PlayerCharacter").GetComponent<SpellCasting>()._spellPrefab;

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

        if (_currentSpell.name == "ChainLightning")
        {
            _chainlightning.SetActive(true);
        }
        else
        {
            _chainlightning.SetActive(false);
        }
    }
}
