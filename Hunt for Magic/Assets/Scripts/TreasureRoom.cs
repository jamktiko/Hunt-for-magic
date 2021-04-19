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
    private GameObject _spawnManager;
    private GameObject _spellArea;
    private GameObject _player;
    private Transform _room;
    [SerializeField]
    private bool _roomClear = false;
    private bool _roomActive;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn Manager");
        _spellArea = GameObject.Find("WeaponArea");
        _player = GameObject.Find("PlayerCharacter");
        _room = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_roomClear && _roomActive)
        {
            _roomActive = false;
            SpawnTreasure();
            if (_player.GetComponent<HealthSystem>().health < _minHealthLevel)
            {
                foreach (Transform healthspawnpoint in _healthSpawnPoints)
                {
                    Instantiate(_healthUp, healthspawnpoint.position, Quaternion.identity, _room);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_roomClear)
        {

            _roomClear = true;
            _roomActive = true;
           
        }
    }
    private void SpawnTreasure()
    {

        int randomIndex = Random.Range(0, _spawnManager.GetComponent<SpawnManager>()._spellList.Count);
        GameObject powerUp = _spawnManager.GetComponent<SpawnManager>()._spellList[randomIndex];
        Debug.Log(powerUp.name);
        if (_spawnManager.GetComponent<SpawnManager>()._spellList != null)
        {
            Instantiate(powerUp, _treasureSpawnPoint.position, Quaternion.identity);
        }

    }
}
