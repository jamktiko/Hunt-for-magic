using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    public Animator _anim;

    private GameObject _slime;

    // Start is called before the first frame update
    void Start()
    {
        _slime = GameObject.Find("EnemySlimePrefab");
        _anim = _slime.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_slime.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            _anim.SetBool("Jump", true);
        }

        if (_slime.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            _anim.SetBool("Jump", false);
        }
    }
}
