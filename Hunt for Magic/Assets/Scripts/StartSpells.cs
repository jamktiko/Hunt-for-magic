using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpells : MonoBehaviour
{
    private Transform _powerUpSpawnLocation;
    public GameObject[] _powerUps;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpSpawnLocation = gameObject.transform;

        SpawnSpell();
    }

    private void SpawnSpell()
    {
        int randomIndex = Random.Range(0, _powerUps.Length);
        GameObject powerUp = _powerUps[randomIndex];
        Instantiate(powerUp, _powerUpSpawnLocation.position, Quaternion.identity);
    }
}
