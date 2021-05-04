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

    private Object _spell0;
    private Object _spell1;
    private Object _spell2;

    private float _electricity = 0.8f;
    private float _wind = 1f;
    private float _lightningbolt = 1.7f;
    private float _water = 2f;
    private float _oil = 2f;
    private float _chainLightning = 2.7f;
    private float _fireball = 3f;
    private float _iceWall = 8f;

    // Start is called before the first frame update
    void Start()
    {
        _player  = GameObject.Find("PlayerCharacter");

        cooldown0.enabled = false;
        cooldown0.fillAmount = 1f;

        cooldown1.enabled = false;
        cooldown1.fillAmount = 1f;

        cooldown2.enabled = false;
        cooldown2.fillAmount = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_weaponArea.GetComponent<SpellBehaviour>()._spell0 != null)
        {
            _spell0 = _weaponArea.GetComponent<SpellBehaviour>()._spell0;
        }
        if (_weaponArea.GetComponent<SpellBehaviour>()._spell1 != null)
        {
            _spell1 = _weaponArea.GetComponent<SpellBehaviour>()._spell1;
        }
        if (_weaponArea.GetComponent<SpellBehaviour>()._spell2 != null)
        {
            _spell2 = _weaponArea.GetComponent<SpellBehaviour>()._spell2;
        }

        if (_player.GetComponent<SpellCasting>()._windCooldown)
        {
            if (_spell0 != null && _spell0.name == "WindEffect")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _wind * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "WindEffect")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _wind * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "WindEffect")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _wind * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "WindEffect")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "WindEffect")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "WindEffect")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<SpellCasting>()._waterCooldown)
        {
            if (_spell0 != null && _spell0.name == "Waterwave")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _water * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "Waterwave")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _water * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "Waterwave")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _water * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "Waterwave")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "Waterwave")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "Waterwave")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<SpellCasting>()._oilCooldown)
        {
            if (_spell0 != null && _spell0.name == "OilSpell")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _oil * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "OilSpell")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _oil * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "OilSpell")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _oil * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "OilSpell")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "OilSpell")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "OilSpell")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<SpellCasting>()._elecCooldown)
        {
            if (_spell0 != null && _spell0.name == "Electricity")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _electricity * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "Electricity")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _electricity * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "Electricity")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _electricity * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "Electricity")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "Electricity")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "Electricity")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<SpellCasting>()._fireballCooldown)
        {
            if (_spell0 != null && _spell0.name == "Fireball")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _fireball * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "Fireball")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _fireball * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "Fireball")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _fireball * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "Fireball")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "Fireball")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "Fireball")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<SpellCasting>()._lightningboltCooldown)
        {
            if (_spell0 != null && _spell0.name == "LightningBolt")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _lightningbolt * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "LightningBolt")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _lightningbolt * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "LightningBolt")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _lightningbolt * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "LightningBolt")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "LightningBolt")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "LightningBolt")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<SpellCasting>()._icewallCooldown)
        {
            if (_spell0 != null && _spell0.name == "IceWallSpell")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _iceWall * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "IceWallSpell")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _iceWall * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "IceWallSpell")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _iceWall * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "IceWallSpell")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "IceWallSpell")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "IceWallSpell")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<EnergySystem>()._currentEnergy < 100f)
        {
            if (_spell0 != null && _spell0.name == "Flamethrower_particle")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount = 0 + _player.GetComponent<EnergySystem>()._currentEnergy / _player.GetComponent<EnergySystem>()._maxEnergy;
            }
            else if (_spell1 != null && _spell1.name == "Flamethrower_particle")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount = 0 + _player.GetComponent<EnergySystem>()._currentEnergy / _player.GetComponent<EnergySystem>()._maxEnergy;
            }
            else if (_spell2 != null && _spell2.name == "Flamethrower_particle")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount = 0 + _player.GetComponent<EnergySystem>()._currentEnergy / _player.GetComponent<EnergySystem>()._maxEnergy;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "Flamethrower_particle")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "Flamethrower_particle")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "Flamethrower_particle")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }

        if (_player.GetComponent<SpellCasting>()._chainlightningCooldown)
        {
            if (_spell0 != null && _spell0.name == "ChainLightning")
            {
                cooldown0.enabled = true;
                cooldown0.fillAmount -= 1 / _chainLightning * Time.deltaTime;
            }
            else if (_spell1 != null && _spell1.name == "ChainLightning")
            {
                cooldown1.enabled = true;
                cooldown1.fillAmount -= 1 / _chainLightning * Time.deltaTime;
            }
            else if (_spell2 != null && _spell2.name == "ChainLightning")
            {
                cooldown2.enabled = true;
                cooldown2.fillAmount -= 1 / _chainLightning * Time.deltaTime;
            }
        }
        else
        {
            if (_spell0 != null && _spell0.name == "ChainLightning")
            {
                cooldown0.enabled = false;
                cooldown0.fillAmount = 1f;
            }
            else if (_spell1 != null && _spell1.name == "ChainLightning")
            {
                cooldown1.enabled = false;
                cooldown1.fillAmount = 1f;
            }
            else if (_spell2 != null && _spell2.name == "ChainLightning")
            {
                cooldown2.enabled = false;
                cooldown2.fillAmount = 1f;
            }
        }
    }
}
