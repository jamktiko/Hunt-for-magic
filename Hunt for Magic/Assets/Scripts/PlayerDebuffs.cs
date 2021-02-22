using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuffs : MonoBehaviour
{
    private GameObject _player;

    [SerializeField]
    private float _playerSpeed = 1.8f;

    [SerializeField]
    public bool _slowed;

    [HideInInspector]
    public bool _slowEnding;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_slowed == true)
        {
            _player.GetComponent<PlayerCharacterController>().speed = _playerSpeed / 2f;

            if (_slowEnding == true)
            {
                StartCoroutine("SlowStopper");
                _slowEnding = false;
            }
        }
    }

    IEnumerator SlowStopper()
    {
        yield return new WaitForSeconds(2f);

        _player.GetComponent<PlayerCharacterController>().speed = _playerSpeed;

        _slowed = false;
    }
}
