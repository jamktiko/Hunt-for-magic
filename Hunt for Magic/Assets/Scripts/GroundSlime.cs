using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlime : MonoBehaviour
{
    private bool _slowed;

    [SerializeField]
    private float _playerSpeed = 1.8f;

    private void Update()
    {
        Invoke("MovementReturn", 5f);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _slowed == false)
        {
            other.GetComponent<PlayerCharacterController>().speed /= 2f;

            _slowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && _slowed == true)
        {
            MovementReturn();
        }
    }

    private void MovementReturn()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerCharacterController>().speed = _playerSpeed;

        _slowed = false;
    }
}
