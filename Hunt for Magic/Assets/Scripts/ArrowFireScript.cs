using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFireScript : MonoBehaviour
{
    private float speed = 8f;
    private float _damageAmount = 10;
    private GameObject hud;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed, ForceMode.Impulse);
        hud = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<HealthSystem>();

        if (player != null && player.tag == "Player")
        {
            player.AddDamage(_damageAmount);
            Destroy(gameObject);

            if (gameObject.name == "FireArrow")
            {
                hud.GetComponentInChildren<PlayerDebuffs>()._onFire = true;
            }
            else if (gameObject.name == "IceArrow")
            {
                hud.GetComponentInChildren<PlayerDebuffs>()._chilled = true;
            }
            else if (gameObject.name == "WindArrow")
            {
                if (hud.GetComponentInChildren<PlayerDebuffs>()._isWet == true)
                {
                    hud.GetComponentInChildren<PlayerDebuffs>()._chilled = true;
                }
            }
            else if (gameObject.name == "WaterArrow")
            {
                hud.GetComponentInChildren<PlayerDebuffs>()._isWet = true;
            }
            else if (gameObject.name == "ThunderArrow")
            {
                if(hud.GetComponentInChildren<PlayerDebuffs>()._isWet == true)
                {
                    player.AddDamage(_damageAmount / 2f);
                }
            }
        }
    }
}
