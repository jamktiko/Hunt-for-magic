using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{

    [SerializeField]
    public float _damageAmount;
    public float FireBonus;
    public GameObject _player;

    private float _wetDamageAmount;

    private GameObject _barrelExplosion;
    private GameObject _groundFire;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        FireBonus = _player.GetComponent<CrystalScript>().fireDamage;
        _damageAmount = FireBonus;
        _wetDamageAmount = _damageAmount * 0.5f;
        _barrelExplosion = Resources.Load<GameObject>("Prefabs/BarrelExplosion");
        _groundFire = Resources.Load<GameObject>("Prefabs/ground_on_fire");
    }

    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject, 3f);

    }

    private void OnParticleCollision(GameObject other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null && enemy.tag == "Monster")
        {
            if (!enemy.name.Contains("Vine"))
            {
                if (enemy.GetComponent<Debuffs>()._wet == true)
                {
                    _damageAmount = _wetDamageAmount;
                }

                enemyHealth.AddDamage(_damageAmount);
                other.GetComponent<Debuffs>()._onFire = true;
            }
            else
            {
                enemyHealth.AddDamage(_damageAmount);
            }
        }

        if (other.name.Contains("ExplodingBarrel"))
        {
            Instantiate(_barrelExplosion, other.transform.position, Quaternion.identity);
            Instantiate(_groundFire, other.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(other);
        }
    }
}