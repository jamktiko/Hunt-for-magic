using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFireScript : MonoBehaviour
{
    private float speed = 4;
    private float _damageAmount = 5f;
    private Transform thisGO;




    // Start is called before the first frame update
    void Start()
    {
        thisGO = gameObject.GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var health = other.gameObject.GetComponent<HealthSystem>();
        //var debuffs = other.gameObject.GetComponent<>();

        if (health != null && health.CompareTag("Player"))
        {
            health.AddDamage(_damageAmount);

            if (thisGO.name.Contains("FireArrow"))
            {
                GameObject.Find("HUD").GetComponentInChildren<PlayerDebuffs>()._onFire = true;
                Destroy(gameObject);
            }
            if (thisGO.name.Contains("IceArrow"))
            {
                GameObject.Find("HUD").GetComponentInChildren<PlayerDebuffs>()._chilled = true;
                Destroy(gameObject);
            }
            if (thisGO.name.Contains("WindArrow"))
            {
                if (GameObject.Find("HUD").GetComponentInChildren<PlayerDebuffs>()._isWet == true)
                {
                    GameObject.Find("HUD").GetComponentInChildren<PlayerDebuffs>()._chilled = true;
                    Destroy(gameObject);
                }
            }
            if (thisGO.name.Contains("WaterArrow"))
            {
                GameObject.Find("HUD").GetComponentInChildren<PlayerDebuffs>()._isWet = true;
                Destroy(gameObject);
            }
            if (thisGO.name.Contains("ThunderArrow"))
            {
                if (GameObject.Find("HUD").GetComponentInChildren<PlayerDebuffs>()._isWet == true)
                {
                    health.AddDamage(_damageAmount / 2f);
                    Destroy(gameObject);
                }
            }

        }
        
    }
}
