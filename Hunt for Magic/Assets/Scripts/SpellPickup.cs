using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPickup : MonoBehaviour
{
    private GameObject _player;
    private GameObject _weaponArea;
    private Transform _spawnPoint;

    private Object _airPickup;
    private Object _chainlightningPickup;
    private Object _elecPickup;
    private Object _fireballPickup;
    private Object _flamethrowerPickup;
    private Object _lightningboltPickup;
    private Object _waterPickup;
    private Object _icePickup;
    private Object _staffPickupWater;
    private Object _staffPickupWind;
    private Object _staffPickupLightning;
    private Object _staffPickupFire;
    private Object staff_Set;

    private AudioSource _menuSrc;
    private AudioClip _pickup;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _spawnPoint = GameObject.Find("SpellDropPoint").GetComponent<Transform>();
        _weaponArea = GameObject.Find("WeaponArea");

        _airPickup = Resources.Load("Prefabs/Air_pickup");
        _chainlightningPickup = Resources.Load("Prefabs/Chainlightning_pickup");
        _elecPickup = Resources.Load("Prefabs/Elec_Pickup");
        _fireballPickup = Resources.Load("Prefabs/Fireball_pickup");
        _flamethrowerPickup = Resources.Load("Prefabs/flamethrower_pickup");
        _lightningboltPickup = Resources.Load("Prefabs/Lightningbolt_pickup");
        _waterPickup = Resources.Load("Prefabs/Water_pickup");
        _icePickup = Resources.Load("Prefabs/Icewall_pickup");
        _staffPickupWater = Resources.Load("Prefabs/TearUpgrade_pickup");
        _staffPickupWind = Resources.Load("Prefabs/NorthUpgrade_pickup");
        _staffPickupLightning = Resources.Load("Prefabs/MagnetUpgrade_pickup");
        _staffPickupFire = Resources.Load("Prefabs/EmberUpgrade_pickup");

        _menuSrc = GameObject.Find("HUD").GetComponent<AudioSource>();
        _pickup = Resources.Load<AudioClip>("SFX/Player/Spells/spell_pickup");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.tag == "Player")
            {
                _menuSrc.PlayOneShot(_pickup);

                if (gameObject.name.Contains("Ember"))
                {
                    other.GetComponent<CrystalScript>().crystalUpgrade = Resources.Load("Prefabs/EmberUpgrade_pickup");
                    Destroy(gameObject);
                }
                if (gameObject.name.Contains("Magnet"))
                {
                    other.GetComponent<CrystalScript>().crystalUpgrade = Resources.Load("Prefabs/MagnetUpgrade_pickup");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Tear"))
                {
                    other.GetComponent<CrystalScript>().crystalUpgrade = Resources.Load("Prefabs/TearUpgrade_pickup");
                    Destroy(gameObject);
                }
                if (gameObject.name.Contains("North"))
                {
                    other.GetComponent<CrystalScript>().crystalUpgrade = Resources.Load("Prefabs/NorthUpgrade_pickup");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Air"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/WindEffect");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Water"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/Waterwave");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Elec"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/Electricity");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("flamethrower"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/Flamethrower_particle");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Fireball"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/Fireball");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Lightningbolt"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/LightningBolt");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Chainlightning"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/ChainLightning");
                    Destroy(gameObject);
                }

                if (gameObject.name.Contains("Ice"))
                {
                    _weaponArea.GetComponent<SpellBehaviour>()._count++;
                    Spawner();
                    _weaponArea.GetComponent<SpellBehaviour>()._newSpell = Resources.Load("Prefabs/IceWallSpell");
                    Destroy(gameObject);
                }
            }
        }
    }

    private void Spawner()
    {
        if (_player.GetComponent<SpellCasting>()._spellPrefab != null && _weaponArea.GetComponent<SpellBehaviour>()._spellSlot2.activeSelf)
        {
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "WindEffect")
            {
                Instantiate(_airPickup, _spawnPoint.position, Quaternion.identity);
            }
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "ChainLightning")
            {
                Instantiate(_chainlightningPickup, _spawnPoint.position, Quaternion.identity);
            }
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "Electricity")
            {
                Instantiate(_elecPickup, _spawnPoint.position, Quaternion.identity);
            }
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "Fireball")
            {
                Instantiate(_fireballPickup, _spawnPoint.position, Quaternion.identity);
            }
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "Flamethrower_particle")
            {
                Instantiate(_flamethrowerPickup, _spawnPoint.position, Quaternion.identity);
            }
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "LightningBolt")
            {
                Instantiate(_lightningboltPickup, _spawnPoint.position, Quaternion.identity);
            }
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "Waterwave")
            {
                Instantiate(_waterPickup, _spawnPoint.position, Quaternion.identity);
            }
            if (_weaponArea.GetComponent<SpellBehaviour>()._newSpell.name == "IceWallSpell")
            {
                Instantiate(_icePickup, _spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
