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
        if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Electricity" | _player.GetComponent<SpellCasting>()._elecCooldown))
        {
            _cooldown.fillAmount -= 1 / 0.8f * Time.deltaTime;

            if (_player.GetComponent<SpellCasting>()._elecCooldown == false)
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "WindEffect" | _player.GetComponent<SpellCasting>()._windCooldown))
        {
            _cooldown.fillAmount -= 1 / 1f * Time.deltaTime;

            if (_player.GetComponent<SpellCasting>()._windCooldown == false)
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "LightningBolt" | _player.GetComponent<SpellCasting>()._lightningboltCooldown))
        {
            if (!Input.GetButton("Fire1"))
            {
                _cooldown.fillAmount -= 1 / 1.7f * Time.deltaTime;

                if (_player.GetComponent<SpellCasting>()._lightningboltCooldown == false)
                {
                    _cooldown.fillAmount = 1f;
                    _cooldown.enabled = false;
                }
            }
            else
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Waterwave" | _player.GetComponent<SpellCasting>()._waterCooldown))
        {
            _cooldown.fillAmount -= 1 / 2f * Time.deltaTime;

            if (_player.GetComponent<SpellCasting>()._waterCooldown == false)
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "ChainLightning" | _player.GetComponent<SpellCasting>()._chainlightningCooldown))
        {
            _cooldown.fillAmount -= 1 / 2f * Time.deltaTime;

            if (_player.GetComponent<SpellCasting>()._chainlightningCooldown == false)
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "OilSpell" | _player.GetComponent<SpellCasting>()._oilCooldown))
        {
            _cooldown.fillAmount -= 1 / 2f * Time.deltaTime;

            if (_player.GetComponent<SpellCasting>()._oilCooldown == false)
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Fireball" | _player.GetComponent<SpellCasting>()._fireballCooldown))
        {
            _cooldown.fillAmount -= 1 / 3f * Time.deltaTime;

            if (_player.GetComponent<SpellCasting>()._fireballCooldown == false)
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && (_player.GetComponent<SpellCasting>()._spellPrefab.name == "IceWallSpell" | _player.GetComponent<SpellCasting>()._icewallCooldown))
        {
            _cooldown.fillAmount -= 1 / 8f * Time.deltaTime;

            if (_player.GetComponent<SpellCasting>()._icewallCooldown == false)
            {
                _cooldown.fillAmount = 1f;
                _cooldown.enabled = false;
            }
        }

        else if (_cooldown.enabled && _player.GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle")
        {
            _cooldown.fillAmount = 1 - _player.GetComponent<EnergySystem>()._currentEnergy / _player.GetComponent<EnergySystem>()._maxEnergy;
        }
    }
}
