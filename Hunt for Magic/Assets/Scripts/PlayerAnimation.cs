using System.Collections;
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
        if(Input.GetKeyDown("space") && _player.GetComponent<CharacterController>().isGrounded)
        {
            anim.SetTrigger("Jump");  //Hyppää välilyönnillä, jos pelaaja on maassa
        }

        if (!_player.GetComponent<CharacterController>().isGrounded && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerJumpTakeoff"))
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

            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("CastingOn", true); //Jatkaa casting-animaatiota, jos pelaaja pitää hiirtä pohjassa
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("CastingOn", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Melee");
        }

        if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
        {
            anim.SetBool("Move", true);
        }

        else if (Input.anyKey == false)
        {
            anim.SetBool("Move", false); //Lopettaa kävelyanimaation tarvittaessa
        }


    }
}
