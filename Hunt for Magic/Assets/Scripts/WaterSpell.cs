using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : MonoBehaviour
{
    [SerializeField]
    private static float _damageAmount = 15f;
    public float _spellRange = 5f;
    public float _spellInterval = 1.0f;
    public static float _throwForce = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DamageFizzle();
        Object.Destroy(gameObject, 15.0f);
    }
    public static void SpawnSpell(GameObject _spellPrefab,Transform _castingPoint)
    {
        GameObject spell = Instantiate(_spellPrefab, _castingPoint.position, _castingPoint.rotation);

        spell.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _throwForce, ForceMode.Impulse);
        DamageFizzle();
    }
    private void OnCollisionEnter(Collision collision)
    {
        var enemy = this.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = this.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            enemy.AddForce(0, 1f, 5f, ForceMode.Impulse);
            enemyHealth.AddDamage(_damageAmount);
        }
    }
    static IEnumerator DamageFizzle()
    {
        yield return new WaitForSeconds(1);
        if (_damageAmount > 0)
        {
            _damageAmount -= 1;
        }
    }

    IEnumerator WaveExpand()
    {
        yield return new WaitForSeconds(0.1f);
        if (this != null)
        {
            Vector3 scale = transform.localScale;
            scale.x += 1;
            transform.localScale = scale;
        }

    }

}
