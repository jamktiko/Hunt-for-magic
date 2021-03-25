using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image cooldown0;
    public Image cooldown1;
    public Image cooldown2;
    private GameObject _player;
    public GameObject _weaponArea;
    private Image cooldown;

    // Start is called before the first frame update
    void Start()
    {
        _player  = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SpellBehaviour._activeSlot == 0 && _player.GetComponent<SpellCasting>()._spellCooldown == false)
        {
            cooldown1.enabled = false;
            cooldown2.enabled = false;

            cooldown = cooldown0;
        }

        else if (SpellBehaviour._activeSlot == 1 && _player.GetComponent<SpellCasting>()._spellCooldown == false)
        {
            cooldown0.enabled = false;
            cooldown2.enabled = false;

            cooldown = cooldown1;
        }

        else if (SpellBehaviour._activeSlot == 2 && _player.GetComponent<SpellCasting>()._spellCooldown == false)
        {
            cooldown0.enabled = false;
            cooldown1.enabled = false;

            cooldown = cooldown2;
        }

        if (_player.GetComponent<SpellCasting>()._spellCooldown == true)
        {
            cooldown.enabled = true;
            cooldown.fillAmount -= 1 / _player.GetComponent<SpellCasting>()._spellInterval * Time.deltaTime;
        }
        else if (_player.GetComponent<EnergySystem>()._currentEnergy < 100 && _player.GetComponent<SpellCasting>()._spellCooldown == false && _player.GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle")
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
