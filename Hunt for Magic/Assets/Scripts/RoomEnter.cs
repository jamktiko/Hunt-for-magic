using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomEnter : MonoBehaviour
{
    [SerializeField]
    private bool _roomActive;
    [SerializeField]
    private bool _roomClear;
    [SerializeField]
    private bool _isRoomEmpty;
    [SerializeField]
    private List<Object> _spawnedEnemies;
    [SerializeField]
    Transform[] _spawnPoints;
    [SerializeField]
    Transform _room;
    // Start is called before the first frame update
    void Start()
    {
        _room = GetComponent<Transform>();
        //Find all the spawn points in parent, this gets also the parent.
        _spawnPoints = GetComponentsInChildren<Transform>();
        //Remove the first item in list to get rid of the parent.
        _spawnPoints = _spawnPoints.Skip(1).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (_roomActive && IsArrayEmpty(_spawnedEnemies))
        {
            _roomActive = false;
            _roomClear = true;
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
            _roomActive = true;
        }
    }

    private void SpawnRandomEnemy(Transform spawnpoint)
    {
        Debug.Log("Spawned enemy");
        Object enemy = Resources.Load("Prefabs/EnemySlimePrefab");
        Instantiate(enemy, spawnpoint.position, Quaternion.identity, _room);
        _spawnedEnemies.Add(enemy);
    }
    private bool IsArrayEmpty(List<Object> essenceArray)
    {
        if (essenceArray == null || essenceArray.Count == 0) return true;
        else
        {
            return false;
        }
    }

}
