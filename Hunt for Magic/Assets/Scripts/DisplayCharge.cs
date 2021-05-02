using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCharge : MonoBehaviour
{
    public TextMeshProUGUI _chargeText0;
    public TextMeshProUGUI _chargeText1;
    public TextMeshProUGUI _chargeText2;
    private GameObject _player;
    private TextMeshProUGUI _chargeText;
    public GameObject _weaponArea;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _chargeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.GetComponent<SpellCasting>()._spellPrefab == null)
            return;

        if (SpellBehaviour._activeSlot == 0)
        {
            _chargeText1.enabled = false;
            _chargeText2.enabled = false;

            _chargeText = _chargeText0;
        }

        else if (SpellBehaviour._activeSlot == 1)
        {
            _chargeText0.enabled = false;
            _chargeText2.enabled = false;

            _chargeText = _chargeText1;
        }

        else if (SpellBehaviour._activeSlot == 2)
        {
            _chargeText0.enabled = false;
            _chargeText1.enabled = false;

            _chargeText = _chargeText2;
        }

        if (_player.GetComponent<EnergySystem>()._currentEnergy < 100 && _player.GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle")
        {
            _chargeText.enabled = true;
            _chargeText.color = Color.Lerp(Color.gray, Color.black, _player.GetComponent<EnergySystem>()._currentEnergy / 100);
            _chargeText.text = Mathf.Round(_player.GetComponent<EnergySystem>()._currentEnergy).ToString();
        }
        else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Electricity")
        {
            _chargeText.enabled = true;
            _chargeText.color = Color.black;
            _chargeText.text = _player.GetComponent<SpellCasting>().ammoCount.ToString();
        }
        else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "LightningBolt")
        {
            _chargeText.enabled = true;
            _chargeText.color = Color.black;
            _chargeText.text = _player.GetComponent<SpellCasting>().chargeCounter.ToString();
        }

        else
        {
            _chargeText.enabled = false;
        }
    }
}
