using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : MonoBehaviour
{
    public Transform _treasureSpawnPoint;
    public Transform[] _healthSpawnPoints;
    public GameObject[] _powerUps;
    public GameObject _healthUp;
    public int _minHealthLevel;
    private GameObject _spellArea;
    private Transform _room;
    private bool _roomClear;
    // Start is called before the first frame update
    void Start()
    {
        _spellArea = GameObject.Find("WeaponArea");
        _room = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.Find("Player") && !_roomClear)
        {
            if (other.GetComponent<HealthSystem>().health < _minHealthLevel)
            {
                foreach (Transform healthspawnpoint in _healthSpawnPoints)
                {
                    Instantiate(_healthUp, healthspawnpoint.position, Quaternion.identity, _room);
                }
            }
            SpawnTreasure();
            _roomClear = true;
        }
    }
    private void SpawnTreasure()
    {
        int randomIndex = Random.Range(0, _powerUps.Length);
        GameObject powerUp = _powerUps[randomIndex];
        while (powerUp == _spellArea.GetComponent<SpellBehaviour>()._spell0 | powerUp == _spellArea.GetComponent<SpellBehaviour>()._spell1 | powerUp == _spellArea.GetComponent<SpellBehaviour>()._spell2)
        {
            randomIndex = Random.Range(0, _powerUps.Length);
            powerUp = _powerUps[randomIndex];
        }
        Instantiate(powerUp, _treasureSpawnPoint.position, Quaternion.identity, _room);
    }
}
