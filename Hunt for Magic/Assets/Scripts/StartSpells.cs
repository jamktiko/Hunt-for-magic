using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpells : MonoBehaviour
{
    public Transform _powerUpSpawnLocation1;
    public Transform _powerUpSpawnLocation2;
    public GameObject[] _powerUps;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSpell();
    }

    private void SpawnSpell()
    {
        int random1 = Random.Range(0, _powerUps.Length);
        int random2 = Random.Range(0, _powerUps.Length);

        while (random2 == random1)
        {
            random2 = Random.Range(0, _powerUps.Length);
        }

        GameObject powerUp1 = _powerUps[random1];
        GameObject powerUp2 = _powerUps[random2];
        Instantiate(powerUp1, _powerUpSpawnLocation1.position, Quaternion.identity);
        Instantiate(powerUp2, _powerUpSpawnLocation2.position, Quaternion.identity);
    }
}
