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
    private int _slot;

    // Start is called before the first frame update
    void Start()
    {
        _player  = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player.GetComponent<SpellCasting>()._windCooldown)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "WindEffect")
            {
                _slot = SpellBehaviour._activeSlot;
            }

            Slot();
        }

        if (_player.GetComponent<SpellCasting>()._waterCooldown)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Waterwave")
            {
                _slot = SpellBehaviour._activeSlot;
            }

            Slot();
        }

        if (_player.GetComponent<SpellCasting>()._elecCooldown)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Electricity")
            {
                _slot = SpellBehaviour._activeSlot;
            }

            Slot();
        }

        if (_player.GetComponent<SpellCasting>()._fireballCooldown)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Fireball")
            {
                _slot = SpellBehaviour._activeSlot;
            }

            Slot();
        }

        if (_player.GetComponent<SpellCasting>()._lightningboltCooldown)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "LightningBolt")
            {
                _slot = SpellBehaviour._activeSlot;
            }

            Slot();
        }

        if (_player.GetComponent<SpellCasting>()._chainlightningCooldown)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "ChainLightning")
            {
                _slot = SpellBehaviour._activeSlot;
            }

            Slot();
        }

        if (_player.GetComponent<EnergySystem>()._currentEnergy < 100)
        {
            if (_player.GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle")
            {
                _slot = SpellBehaviour._activeSlot;
            }

            Slot();
        }
    }

    private void Slot()
    {
        if (_slot == 0)
        {
            if (cooldown0.enabled)
                return;

            cooldown0.enabled = true;
        }
        else if (_slot == 1)
        {
            if (cooldown1.enabled)
                return;

            cooldown1.enabled = true;
        }
        else if (_slot == 2)
        {
            if (cooldown2.enabled)
                return;

            cooldown2.enabled = true;
        }
    }
}
