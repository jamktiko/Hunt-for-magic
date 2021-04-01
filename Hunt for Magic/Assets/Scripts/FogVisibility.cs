using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogVisibility : MonoBehaviour
{
    [SerializeField]
    private float _slimeRange = 5f;

    private GameObject _player;

    private GameObject[] _enemies;

    private void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _enemies = GameObject.FindGameObjectsWithTag("Monster");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerDebuffs>()._inFog = true;
        }

        if (other.name.Contains("EnemySlimePrefab"))
        {
            other.GetComponent<EnemySlimeMovement>()._inFog = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerDebuffs>()._inFog = false;
        }

        if (other.name.Contains("EnemySlimePrefab"))
        {
            other.GetComponent<EnemySlimeMovement>()._inFog = false;
        }
    }

    private void OnDestroy()
    {
        _player.GetComponent<PlayerDebuffs>()._inFog = false;
        foreach (GameObject enemy in _enemies)
        {
            if (enemy.name.Contains("EnemySlimePrefab"))
            {
                enemy.GetComponent<EnemySlimeMovement>()._inFog = false;
            }
        }
    }
}
