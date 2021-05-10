using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFireScript : MonoBehaviour
{
    private float speed = 4;
    private float _damageAmount = 2.5f;

    private GameObject _barrelExplosion;
    private GameObject _groundFire;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed, ForceMode.Impulse);

        _barrelExplosion = Resources.Load<GameObject>("Prefabs/BarrelExplosion");
        _groundFire = Resources.Load<GameObject>("Prefabs/ground_on_fire");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject.transform.parent.gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var health = other.gameObject.GetComponent<HealthSystem>();
        var debuffs = GameObject.FindWithTag("HUD").GetComponent<PlayerDebuffs>();

        if (health != null && health.CompareTag("Player"))
        {
            health.AddDamage(_damageAmount);

            if (gameObject.transform.parent.name.Contains("Fire"))
            {               
                debuffs._onFire = true;
                Destroy(gameObject);
            }
            if (gameObject.transform.parent.name.Contains("Ice"))
            {
                debuffs._chilled = true;
                Destroy(gameObject);
            }
            if (gameObject.transform.parent.name.Contains("Wind"))
            {

                if (debuffs._isWet == true)
                {
                    debuffs._chilled = true;
                    Destroy(gameObject);
                }
            }
            if (gameObject.transform.parent.name.Contains("Water"))
            {
                debuffs._isWet = true;
                Destroy(gameObject);
            }
            if (gameObject.transform.parent.name.Contains("Thunder"))
            {
                if (debuffs._isWet == true)
                {
                    health.AddDamage(_damageAmount);
                    Destroy(gameObject);
                }
            }

        }

        if (other.gameObject.name.Contains("Barrel"))
        {
            Instantiate(_barrelExplosion, other.transform.position, Quaternion.identity);
            Instantiate(_groundFire, other.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
