using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogVisibility : MonoBehaviour
{
    [SerializeField]
    private float _slimeRange = 5f;

    private GameObject[] _enemies;

    private GameObject _hud;

    private void Start()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Monster");
        _hud = GameObject.Find("HUD");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _hud.GetComponentInChildren<PlayerDebuffs>()._inFog = true;
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
            _hud.GetComponentInChildren<PlayerDebuffs>()._inFog = false;
        }

        if (other.name.Contains("EnemySlimePrefab"))
        {
            other.GetComponent<EnemySlimeMovement>()._inFog = false;
        }
    }

    private void OnDestroy()
    {
        _hud.GetComponentInChildren<PlayerDebuffs>()._inFog = false;
        foreach (GameObject enemy in _enemies)
        {
            if (enemy.name.Contains("EnemySlimePrefab"))
            {
                enemy.GetComponent<EnemySlimeMovement>()._inFog = false;
            }
        }
    }
}
