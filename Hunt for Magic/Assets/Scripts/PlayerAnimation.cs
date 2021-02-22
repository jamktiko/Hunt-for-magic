using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            anim.Play("PlayerJump", -1, 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("PlayerCasting", -1, 0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("PlayerMelee", -1, 0f);
        }
    }
}
