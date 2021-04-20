using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");

        _player.transform.position = gameObject.transform.position;
    }
}
