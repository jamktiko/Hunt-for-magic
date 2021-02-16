using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 15f;
<<<<<<< Updated upstream
    public float _spellRange = 5f;
    public float _spellInterval = 1.0f;
=======
    private float _speed = 5f;

    private Transform _castingPoint;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {

        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 15.0f);
    }
<<<<<<< Updated upstream
    public static void SpawnSpell(GameObject _spellPrefab,Transform _castingPoint, float _throwForce)
    {
        GameObject spell = Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

        spell.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _throwForce, ForceMode.Impulse);

    }
    private void OnCollisionEnter(Collision collision)
    {
        var enemy = this.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = this.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            enemy.AddForce(0, 1f, 5f, ForceMode.Impulse);
            enemyHealth.AddDamage(_damageAmount);
            Destroy(gameObject);
        }
    }
    IEnumerator DamageFizzle()
=======
    private void OnTriggerEnter(Collider other)
>>>>>>> Stashed changes
    {
        if (other.gameObject.tag != "Player")
        {
            var enemy = other.gameObject.GetComponent<Rigidbody>();

            var enemyHealth = other.gameObject.GetComponent<HealthSystem>();
            if (enemy != null)
            {
                enemy.AddForce(0, 1f, 5f, ForceMode.Impulse);
                enemyHealth.AddDamage(_damageAmount);
            }
        }


        
    }

    //static IEnumerator DamageFizzle()
    //{
    //    yield return new WaitForSeconds(1);
    //    if (_damageAmount > 0)
    //    {
    //        _damageAmount -= 1;
    //    }
    //}


}
