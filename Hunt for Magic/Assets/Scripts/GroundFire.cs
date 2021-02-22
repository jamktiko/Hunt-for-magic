using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFire : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 0.01f;

    private GameObject _fog;

    // Start is called before the first frame update
    void Start()
    {
        _fog = Resources.Load<GameObject>("Prefabs/Fog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.name != "PlayerCharacter")
        {
            if (other.name == "SphereCollider")
            {
                Destroy(gameObject);
            }

            else if (other.name == "WaterSphere")
            {
                Destroy(gameObject);
                GameObject fog = Instantiate(_fog, transform.position, Quaternion.identity);
                Destroy(fog, 7f);
            }

            else
            {
                enemyHealth.AddDamage(_damageAmount);
                other.GetComponent<Debuffs>()._onFire = true;
            }
        }
    }
}
