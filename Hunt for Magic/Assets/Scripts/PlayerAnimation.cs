﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _player = GameObject.Find("PlayerCharacter");  //Pelaaja
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.GetComponent<CharacterController>().isGrounded && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerJumpTakeoff") && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee") && anim.GetBool("Dodgedash") == false && anim.GetBool("CastingOn") == false)
        {
            anim.SetBool("OnAir", true);
        }

        else
        {
            anim.SetBool("OnAir", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Casting");

            if (Input.GetMouseButton(0) && GetComponentInParent<EnergySystem>()._currentEnergy > 5f)
            {
                anim.SetBool("CastingOn", true); //Jatkaa casting-animaatiota, jos pelaaja pitää hiirtä pohjassa
            }
        }

        else if (Input.GetKeyDown("space") && _player.GetComponent<CharacterController>().isGrounded && anim.GetBool("CastingOn") == false)
        {
            anim.SetTrigger("Jump");  //Hyppää välilyönnillä, jos pelaaja on maassa
        }

        if (Input.GetMouseButtonUp(0) || GetComponentInParent<EnergySystem>()._currentEnergy < 5f)
        {
            anim.SetBool("CastingOn", false);
        }

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            anim.SetBool("Move", true);
        }

        else
        {
            anim.SetBool("Move", false); //Lopettaa kävelyanimaation tarvittaessa
        }

        if (_player.GetComponent<PlayerCharacterController>().speed == 6.25f && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee"))
        {
            anim.SetBool("Dodgedash", true);
        }

        else
        {
            anim.SetBool("Dodgedash", false);
        }
    }
}
