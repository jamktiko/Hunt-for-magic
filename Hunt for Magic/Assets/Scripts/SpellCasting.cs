using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour  // Tämä scripti liitetään pelaajaan
{
    [SerializeField]
    private Object _spellPrefab;

    private Transform _castingPoint;
    private Transform _waterCastingPoint;

    private bool _spellCooldown;

    [SerializeField]
    private float _spellInterval = 1f;

    private GameObject _player;

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
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("1"))
        {
            _spellPrefab = Resources.Load("Prefabs/WindEffect");
        }

        if (Input.GetKeyDown("2"))
        {
            _spellPrefab = Resources.Load("Prefabs/Waterwave");
        }

        if (Input.GetKeyDown("3"))
        {
            _spellPrefab = Resources.Load("Prefabs/Fireball");
        }

        if (Input.GetKeyDown("4"))
        {
            _spellPrefab = Resources.Load("Prefabs/Electricity");
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

        if (Input.GetButtonDown("Fire1"))
        {

            if (_spellPrefab.name == "WindEffect")
            {
                if (_spellCooldown)
                {
                    return;
                }
                Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

                _spellCooldown = true;

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

                Invoke("EndCooldown", _spellInterval);
            }

            if (_spellPrefab.name == "ChainLightningPrefab")
            {
                canChargeSpell = true;

                _spellCooldown = true;

                Invoke("EndCooldown", _spellInterval);
            }
        }
        if (Input.GetButtonUp("Fire1") || chargeCounter == 6)
        {
            if (_spellPrefab.name == "ChainLightningPrefab")
            {
                    canChargeSpell = false;
                    Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);
                    chargeCounter = 0;
            }
        }
    }

        public void EndCooldown()
        {
            _spellCooldown = false;
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
                        ammoCount = ammoCount + ammoChanger;
                }
            }
        }

    IEnumerator ChargeCooldown()
    {
        yield return new WaitForSeconds(2.2f);
        if (canChargeSpell)
        {
            if (chargeChancerCooldown)

                chargeChancerCooldown = false;

                if(ammoCount < 6)
                {
                    chargeCounter++;
                    ammoCount--;
                }
        }
    }
}
