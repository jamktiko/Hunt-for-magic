using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCasting : MonoBehaviour  // Tämä scripti liitetään pelaajaan
{
    [SerializeField]
    public Object _spellPrefab;

    private Transform _castingPoint;
    private Transform _waterCastingPoint;

    public bool _windCooldown;
    public bool _waterCooldown;
    public bool _elecCooldown;
    public bool _fireballCooldown;
    public bool _lightningboltCooldown;
    public bool _chainlightningCooldown;
    public bool _icewallCooldown;

    [SerializeField]
    public float _spellInterval = 1f;

    private GameObject _player;

    [SerializeField]
    private float _throwForce = 20f;

    public GameObject _weaponArea;

    public float ammoCount = 1;
    public float ammoChanger = 1;
    public float maxAmmo = 3;
    public float chargeCounter = 0;
    public float spellCharge = 0;
    public bool ammoChangerCooldown = false;
    public bool canCharge = false;
    public bool canChargeSpell = false;
    public bool chargeChancerCooldown = false;
    private bool alreadyCast = false;

    // Start is called before the first frame update
    void Start()
    {
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _player = GameObject.Find("PlayerCharacter");
        _weaponArea = GameObject.Find("WeaponArea");
    }

    // Update is called once per frame
    void Update()
    {

        if (!ammoChangerCooldown)
        {
            maxAmmo = gameObject.GetComponent<CrystalScript>().chargeCount;
            if (ammoCount < maxAmmo)
            {
                canCharge = true;
                ammoChangerCooldown = true;
                StartCoroutine(ammoChangerInitiate());
            }
        }

        if (canChargeSpell)
        {
            if (!chargeChancerCooldown)
            {
                if (ammoCount > 0)
                {
                    chargeChancerCooldown = true;
                    StartCoroutine(ChargeCooldown());
                }
            }
        }

        if (_spellPrefab == null)
            return;

        if (Input.GetButton("Fire1"))
        {

            if (_spellPrefab.name == "WindEffect")
            {
                if (_windCooldown)
                {
                    return;
                }

                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

                _windCooldown = true;

                StartCoroutine(EndWindCooldown());
            }

            if (_spellPrefab.name == "Waterwave" && PlayerCharacterController.isGrounded)
            {
                if (_waterCooldown)
                {
                    return;
                }

                Instantiate(_spellPrefab, _waterCastingPoint.position, _waterCastingPoint.rotation);

                _waterCooldown = true;

                StartCoroutine(EndWaterCooldown());
            }

            if (_spellPrefab.name == "Electricity")
            {
                if (_elecCooldown)
                {
                    return;
                }

                if (ammoCount >= 1)
                {
                    ammoCount = ammoCount - ammoChanger;
                    Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
                }

                _elecCooldown = true;

                StartCoroutine(EndElecCooldown());
            }

            if (_spellPrefab.name == "Fireball")
            {
                if (_fireballCooldown)
                {
                    return;
                }

                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

                _fireballCooldown = true;

                StartCoroutine(EndFireballCooldown());
            }

            if (_spellPrefab.name == "ChainLightning")
            {
                if (ammoCount > 0)
                {
                    if (_chainlightningCooldown)
                    {
                        return;
                    }
                    _spellInterval = 2f;

                    canChargeSpell = true;

                    ammoCount--;
                    chargeCounter++;

                    _chainlightningCooldown = true;
                }
            }

            if (_spellPrefab.name == "LightningBolt")
            {
                if (ammoCount > 0)
                {
                    if (_lightningboltCooldown)
                    {
                        return;
                    }
                    _spellInterval = 1.7f;

                    canChargeSpell = true;

                    ammoCount--;
                    chargeCounter++;

                    _lightningboltCooldown = true;
                }
            }

            if (_spellPrefab.name == "IceWallSpell")
            {
                if (_icewallCooldown)
                {
                    return;
                }

                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

                _icewallCooldown = true;

                StartCoroutine(EndIcewallCooldown());
            }
        }
        if (Input.GetButtonUp("Fire1") || chargeCounter == 6)
        {
            if (!alreadyCast && chargeCounter != 0)
            {
                if (_spellPrefab.name == "ChainLightning")
                {
                    spellCharge = chargeCounter;
                    canChargeSpell = false;
                    Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
                    alreadyCast = true;
                    chargeChancerCooldown = false;
                    StartCoroutine(EndChainlightningCooldown());
                    chargeCounter = 0;
                }

                if (_spellPrefab.name == "LightningBolt")
                {
                    spellCharge = chargeCounter;
                    canChargeSpell = false;
                    Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
                    alreadyCast = true;
                    chargeChancerCooldown = false;
                    StartCoroutine(EndLightningboltCooldown());
                    chargeCounter = 0;
                }
            }
            else if (alreadyCast)
            {
                alreadyCast = false;
            }

        }
    }

    private void FixedUpdate()
    {
        if (_spellPrefab == null)
            return;

        if (Input.GetButton("Fire1"))
        {
            if (_spellPrefab.name == "Flamethrower_particle")
            {
                _player.GetComponent<EnergySystem>().ReduceEnergy(1f);
                _spellInterval = 1.5f;

                if (_player.GetComponent<EnergySystem>()._currentEnergy < 5)
                {
                    return;
                }

                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
            }
        }
    }

    IEnumerator EndWindCooldown()
    {
        yield return new WaitForSeconds(1f);

        _windCooldown = false;
    }
    IEnumerator EndWaterCooldown()
    {
        yield return new WaitForSeconds(2f);

        _waterCooldown = false;
    }
    IEnumerator EndElecCooldown()
    {
        yield return new WaitForSeconds(0.8f);

        _elecCooldown = false;
    }
    IEnumerator EndFireballCooldown()
    {
        yield return new WaitForSeconds(3f);

        _fireballCooldown = false;
    }

    IEnumerator EndLightningboltCooldown()
    {
        yield return new WaitForSeconds(1.7f);

        _lightningboltCooldown = false;
    }

    IEnumerator EndChainlightningCooldown()
    {
        yield return new WaitForSeconds(2f);

        _chainlightningCooldown = false;
    }

    IEnumerator EndIcewallCooldown()
    {
        yield return new WaitForSeconds(8f);

        _icewallCooldown = false;
    }

    IEnumerator ammoChangerInitiate()
    {
        yield return new WaitForSeconds(3.5f);
        if (canCharge)
        {
            if (ammoChangerCooldown)
            {
                ammoChangerCooldown = false;

                if (ammoCount < maxAmmo)
                {
                    ammoCount = ammoCount + ammoChanger;
                }
            }
        }
    }

    IEnumerator ChargeCooldown()
    {
        yield return new WaitForSeconds(2.2f);
        if (canChargeSpell)
        {
            if (chargeChancerCooldown)
            {

                chargeChancerCooldown = false;

                if (chargeCounter < 6)
                {
                    chargeCounter++;
                    ammoCount--;
                }
            }
        }
    }
}
