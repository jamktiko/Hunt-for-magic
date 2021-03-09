﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCasting : MonoBehaviour  // Tämä scripti liitetään pelaajaan
{
    [SerializeField]
    private Object _spellPrefab;

    private Transform _castingPoint;
    private Transform _waterCastingPoint;

    [SerializeField]
    private bool _spellCooldown;

    [SerializeField]
    private float _spellInterval = 1f;

    private GameObject _player;

    private Image _cooldownImage;

    [SerializeField]
    private float _throwForce = 20f;

    public float ammoCount = 1;
    public float ammoChanger = 1;
    public float maxAmmo = 3;
    public float chargeCounter = 0;
    public bool ammoChangerCooldown = false;
    public bool canCharge = false;
    private bool canChargeSpell = false;
    private bool chargeChancerCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        _cooldownImage = GameObject.Find("Cooldown").GetComponent<Image>();
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _player = GameObject.Find("PlayerCharacter");
        _cooldownImage.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("1"))
        {
            _spellPrefab = Resources.Load("Prefabs/Flamethrower_particle");
        }

        if (Input.GetKeyDown("2"))
        {
            _spellPrefab = Resources.Load("Prefabs/WindEffect");
        }

        if (Input.GetKeyDown("3"))
        {
            _spellPrefab = Resources.Load("Prefabs/Electricity");
        }

        if (Input.GetKeyDown("4"))
        {
            _spellPrefab = Resources.Load("Prefabs/Waterwave");
        }

        if (Input.GetKeyDown("5"))
        {
            _spellPrefab = Resources.Load("Prefabs/Fireball");
        }

        if (Input.GetKeyDown("6"))
        {
            _spellPrefab = Resources.Load("Prefabs/ChainLightning");
        }

        if (!ammoChangerCooldown)
        {
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


        if (Input.GetButton("Fire1"))
        {

            if (_spellPrefab.name == "WindEffect")
            {
                if (_spellCooldown)
                {
                    return;
                }
                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

                _spellCooldown = true;
                StartCoroutine("CoolDownImage");
                Invoke("EndCooldown", _spellInterval);
            }

            if (_spellPrefab.name == "Flamethrower_particle")
            {
                _player.GetComponent<EnergySystem>().ReduceEnergy(1f);

                if (_player.GetComponent<EnergySystem>()._currentEnergy < 5)
                {
                    return;
                }

                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
            }

            if (_spellPrefab.name == "Waterwave" && PlayerCharacterController.isGrounded)
            {
                if (_spellCooldown)
                {
                    return;
                }
                Instantiate(_spellPrefab, _waterCastingPoint.position, _waterCastingPoint.rotation);

                _spellCooldown = true;
                StartCoroutine("CoolDownImage");
                Invoke("EndCooldown", _spellInterval);
            }

            if (_spellPrefab.name == "Electricity")
            {
                if (_spellCooldown)
                {
                    return;
                }

                if (ammoCount >= 1)
                {
                    ammoCount = ammoCount - ammoChanger;
                    Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
                }

                _spellCooldown = true;
                StartCoroutine("CoolDownImage");
                Invoke("EndCooldown", _spellInterval);
            }

            if (_spellPrefab.name == "Fireball")
            {
                if (_spellCooldown)
                {
                    return;
                }

                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

                _spellCooldown = true;
                StartCoroutine("CoolDownImage");
                Invoke("EndCooldown", _spellInterval);
            }

            if (_spellPrefab.name == "ChainLightning")
            {
                if (ammoCount > 0)
                {
                    if (_spellCooldown)
                    {
                        return;
                    }
                    canChargeSpell = true;

                    ammoCount--;
                    chargeCounter++;

                    _spellCooldown = true;
                }
            }

            if (_spellPrefab.name == "LightningBolt")
            {
                if (ammoCount > 0)
                {
                    if (_spellCooldown)
                    {
                        return;
                    }
                    canChargeSpell = true;

                    ammoCount--;
                    chargeCounter++;

                    _spellCooldown = true;
                }
            }
        }
        if (Input.GetButtonUp("Fire1") || chargeCounter == 6)
        {
            if (_spellPrefab.name == "ChainLightning")
            {
                canChargeSpell = false;
                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
                chargeCounter = 0;
                Invoke("EndCooldown", _spellInterval);
            }

            if (_spellPrefab.name == "LightningBolt")
            {
                canChargeSpell = false;
                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
                chargeCounter = 0;
                Invoke("EndCooldown", _spellInterval);
            }
        }
    }

        public void EndCooldown()
        {
            _spellCooldown = false;
        }

        IEnumerator CoolDownImage()
    {
        yield return new WaitForSeconds(1);
        float spellCooldown = 1.0f;
        _cooldownImage.enabled = true;
        _cooldownImage.fillAmount = 1.0f;
        while (spellCooldown > 0)
        {
            _cooldownImage.fillAmount -= 0.01f;
            spellCooldown -= Time.deltaTime;
        }
        _cooldownImage.enabled = false;
        _cooldownImage.fillAmount = 1.0f;
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
