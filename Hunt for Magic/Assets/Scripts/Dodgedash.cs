using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgedash : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 1.8f;

    [HideInInspector]
    public bool _dodgeDash;

    [SerializeField]
    private bool _coolDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _coolDown == false)
        {
            StartCoroutine("Dodge");
        }
    }

    IEnumerator Dodge()
    {
        _coolDown = true;

        _dodgeDash = true;

        gameObject.GetComponent<PlayerCharacterController>().speed *= 2.5f;

        yield return new WaitForSeconds(0.3f);

        gameObject.GetComponent<PlayerCharacterController>().speed = _playerSpeed;

        _dodgeDash = false;

        yield return new WaitForSeconds(5f);

        _coolDown = false;
    }
}
