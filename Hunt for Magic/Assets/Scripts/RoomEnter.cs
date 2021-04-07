using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomEnter : MonoBehaviour
{
    public bool _roomActive;
    public GameObject[] _powerUps;
    public GameObject[] _enemies;
    public GameObject healthPickup;
    [SerializeField]
    private bool _roomClear;
    [SerializeField]
    private bool _isRoomEmpty;
    [SerializeField]
    private Object[] _spawnedEnemies;
    public Transform _powerUpSpawnLocation;
    public Transform[] _spawnPoints;
    [SerializeField]
    Transform _room;
    public int _enemyCount;
    public GameObject[] _doors;
    // Start is called before the first frame update
    void Start()
    {
        _room = GetComponent<Transform>();
        foreach (GameObject door in _doors)
        {
            door.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _spawnedEnemies = GameObject.FindGameObjectsWithTag("Monster");
        if (_roomActive && IsArrayEmpty(_spawnedEnemies))
        {
            _roomActive = false;
            _roomClear = true;
            foreach (GameObject door in _doors)
            {
                door.SetActive(false);
            }
            SpawnRandomPickup();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && !_roomActive && !_roomClear)
        {

            foreach (Transform spawnpoint in _spawnPoints)
            {
                if (spawnpoint.gameObject.GetInstanceID() != GetInstanceID())
                {
                    SpawnRandomEnemy(spawnpoint);
                }
            }
            foreach (GameObject door in _doors)
            {
                door.SetActive(true);
            }
            _roomActive = true;
        }
    }

    private void SpawnRandomEnemy(Transform spawnpoint)
    {
        
        Object enemy = Resources.Load("Prefabs/EnemySlimePrefab");
        Instantiate(enemy, spawnpoint.position, Quaternion.identity, _room);
    }
    private void SpawnRandomPickup()
    {
        int pickupDropType = Random.Range(0, 2);
        if (pickupDropType == 0)
        {
            int randomIndex = Random.Range(0, _powerUps.Length);
            GameObject powerUp = _powerUps[randomIndex];
            Instantiate(powerUp, _powerUpSpawnLocation.position, Quaternion.identity, _room);
        } else
        {
            Instantiate(healthPickup, _powerUpSpawnLocation.position, Quaternion.identity, _room);
        }
    }
    private bool IsArrayEmpty(Object[] essenceArray)
    {
        if (essenceArray == null || essenceArray.Length == 0) return true;
        else
        {
            return false;
        }
    }
}