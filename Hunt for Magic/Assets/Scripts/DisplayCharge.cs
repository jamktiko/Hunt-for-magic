using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCharge : MonoBehaviour
{
    private GameObject _player;
    private TextMeshProUGUI _chargeText;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _chargeText = GetComponent<TextMeshProUGUI>();
        _chargeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.GetComponent<EnergySystem>()._currentEnergy < 100 && _player.GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle")
        {
            _chargeText.enabled = true;
            _chargeText.color = Color.white;
            _chargeText.text = Mathf.Round(_player.GetComponent<EnergySystem>()._currentEnergy).ToString();
        }
        else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Electricity")
        {
            _chargeText.enabled = true;
            _chargeText.color = Color.black;
            _chargeText.text = _player.GetComponent<SpellCasting>().ammoCount.ToString();
        }

        else
        {
            _chargeText.enabled = false;
        }
    }
}
