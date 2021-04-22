using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public Animator _anim;
    private GameObject _spawnManager;
    public Transform _treasureSpawnPoint;
    public GameObject _healthUp;
    private bool _chestOpen;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {

            _anim.SetBool("Open", true);
            StartCoroutine(WaitOneSecond());
        }
    }
    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1.0f);
        SpawnTreasure();
    }
    private void SpawnTreasure()
    {

        if (!_chestOpen)
        {
            _chestOpen = true;
            int randomIndex = Random.Range(0, _spawnManager.GetComponent<SpawnManager>()._spellList.Count);
            GameObject powerUp = _spawnManager.GetComponent<SpawnManager>()._spellList[randomIndex];
            Debug.Log(powerUp.name);
            if (_spawnManager.GetComponent<SpawnManager>()._spellList != null)
            {
                Instantiate(powerUp, _treasureSpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_healthUp, _treasureSpawnPoint.position, Quaternion.identity);
            }
            
        }

    }
}
