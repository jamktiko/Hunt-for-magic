using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownImage : MonoBehaviour
{
    private GameObject _player;
    private Image _cooldown;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _cooldown = GetComponent<Image>();
        _cooldown.fillAmount = 1;
        _cooldown.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_cooldown.enabled)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "WindEffect")
            {
                _cooldown.fillAmount -= 1 / 1f * Time.deltaTime;
                Invoke("Disable", 1f);
            }

            else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Waterwave")
            {
                _cooldown.fillAmount -= 1 / 2f * Time.deltaTime;
                Invoke("Disable", 2f);
            }

            else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Electricity")
            {
                _cooldown.fillAmount -= 1 / 0.8f * Time.deltaTime;
                Invoke("Disable", 0.8f);
            }

            else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Fireball")
            {
                _cooldown.fillAmount -= 1 / 3f * Time.deltaTime;
                Invoke("Disable", 3f);
            }

            else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "LightningBolt")
            {
                _cooldown.fillAmount -= 1 / 1.7f * Time.deltaTime;
                Invoke("Disable", 1.7f);
            }

            else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "ChainLightning")
            {
                _cooldown.fillAmount -= 1 / 2f * Time.deltaTime;
                Invoke("Disable", 2f);
            }

            else if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle")
            {
                _cooldown.fillAmount = 1 - _player.GetComponent<EnergySystem>()._currentEnergy / _player.GetComponent<EnergySystem>()._maxEnergy;
            }
        }
    }

    void Disable()
    {
        _cooldown.fillAmount = 1f;
        _cooldown.enabled = false;
    }
}
