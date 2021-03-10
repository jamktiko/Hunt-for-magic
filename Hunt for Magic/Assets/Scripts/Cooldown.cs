using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    private static Image cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = GetComponent<Image>();
        cooldown.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpellCasting._spellCooldown == true)
        {
            cooldown.enabled = true;
            cooldown.fillAmount -= 1.0f * Time.deltaTime;
        }
        else
        {
            cooldown.enabled = false;
            cooldown.fillAmount = 1.0f;
        }

    }
}
