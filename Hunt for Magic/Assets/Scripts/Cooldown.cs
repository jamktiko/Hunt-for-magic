using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    private static Image cooldown;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player  = GameObject.Find("PlayerCharacter");
        cooldown = GetComponent<Image>();
        cooldown.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SpellCasting._spellCooldown == true)
        {
            cooldown.enabled = true;
            cooldown.fillAmount -= 1 / _player.GetComponent<SpellCasting>()._spellInterval * Time.deltaTime;
        }
        else if (_player.GetComponent<EnergySystem>()._currentEnergy < 100 && SpellCasting._spellCooldown == false)
        {
            cooldown.enabled = true;
            cooldown.fillAmount = 1 - _player.GetComponent<EnergySystem>()._currentEnergy / _player.GetComponent<EnergySystem>()._maxEnergy;
        }
        else
        {
            cooldown.enabled = false;
            cooldown.fillAmount = 1.0f;
        }

    }
}
