using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlime : MonoBehaviour
{
    private bool _slowed;

    [SerializeField]
    private float _playerSpeed = 1.8f;

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
            Invoke("MovementReturn", 2f);
        }
    }

    private void MovementReturn()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerCharacterController>().speed = _playerSpeed;

        _slowed = false;
    }
}
