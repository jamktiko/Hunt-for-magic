using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownImage : MonoBehaviour
{
    private GameObject _player;
    private Image _cooldown;
    private SpellCasting _sc;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _cooldown = GetComponent<Image>();
        _cooldown.fillAmount = 1;
        _cooldown.enabled = false;
        _sc = _player.GetComponent<SpellCasting>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_cooldown.enabled)
        {
            if (_player.GetComponent<SpellCasting>()._elecCooldown)
            {
                _cooldown.fillAmount -= 1 / 0.8f * Time.deltaTime;
            }

            if (_player.GetComponent<SpellCasting>()._windCooldown)
            {
                _cooldown.fillAmount -= 1 / 1f * Time.deltaTime;
            }

            if (_player.GetComponent<SpellCasting>()._lightningboltCooldown)
            {
                if (!Input.GetButton("Fire1"))
                {
                    _cooldown.fillAmount -= 1 / 1.7f * Time.deltaTime;
                }
            }

            if (_player.GetComponent<SpellCasting>()._waterCooldown | _player.GetComponent<SpellCasting>()._chainlightningCooldown 
                | _player.GetComponent<SpellCasting>()._oilCooldown)
            {
                _cooldown.fillAmount -= 1 / 2f * Time.deltaTime;
            }

            if (_player.GetComponent<SpellCasting>()._fireballCooldown)
            {
                _cooldown.fillAmount -= 1 / 3f * Time.deltaTime;
            }

            if (_player.GetComponent<SpellCasting>()._icewallCooldown)
            {
                _cooldown.fillAmount -= 1 / 8f * Time.deltaTime;
            }

            // if (_player.GetComponent<EnergySystem>()._currentEnergy != 100f && _sc._spellPrefab.name == "Flamethrower_particle")
            // {
            //     _cooldown.fillAmount = 0 + _player.GetComponent<EnergySystem>()._currentEnergy / _player.GetComponent<EnergySystem>()._maxEnergy;
            // }
        }

        if (!_sc._chainlightningCooldown && !_sc._elecCooldown && !_sc._fireballCooldown && (!_sc._icewallCooldown | _sc._spellPrefab.name != "IceWallSpell") 
             && !_sc._lightningboltCooldown && !_sc._oilCooldown && !_sc._waterCooldown && !_sc._windCooldown
             && _player.GetComponent<EnergySystem>()._currentEnergy > 5f)
        {
            _cooldown.enabled = false;
            _cooldown.fillAmount = 1f;
        }
    }
}
