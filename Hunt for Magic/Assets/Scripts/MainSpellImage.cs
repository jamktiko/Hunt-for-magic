using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSpellImage : MonoBehaviour
{
    private Object _spellImage;

    private Object _currentSpell;

    // Start is called before the first frame update
    void Start()
    {
        _spellImage = gameObject.GetComponent<Image>();
        _currentSpell = GameObject.Find("PlayerCharacter").GetComponent<SpellCasting>()._spellPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentSpell.name == "Flamethrower_particle")
        {
            _spellImage = Resources.Load("hud/Spellfire");
        }

        if (_currentSpell.name == "WindEffect")
        {
            _spellImage = Resources.Load("hud/spell_wind");
        }

        if (_currentSpell.name == "Electricity")
        {
            _spellImage = Resources.Load("hud/spell_Elec");
        }

        if (_currentSpell.name == "Waterwave")
        {
            _spellImage = Resources.Load("hud/spell_water");
        }

        if (_currentSpell.name == "Fireball")
        {
            _spellImage = Resources.Load("hud/spell_fireball");
        }

        if (_currentSpell.name == "ChainLightning")
        {
            _spellImage = Resources.Load("hud/ChainLightning");
        }
    }
}
