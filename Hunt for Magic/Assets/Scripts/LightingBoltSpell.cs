using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBoltSpell : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount = 25f;
    private Transform _castingPoint;
    private float speed = 20f;
    public float chargeCounter;

    // Start is called before the first frame update
    void Start()
    {

        GameObject player = GameObject.Find("PlayerCharacter");
        chargeCounter = player.GetComponent<SpellCasting>().chargeCounter;
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2.1f);
    }

    private void OnTriggerEnter(Collider other)

    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();
        if (chargeCounter > 1)
        {

            if (enemy != null)
            {
                enemyHealth.AddDamage(_damageAmount);
                chargeCounter--;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        var enemyHealth = other.gameObject.GetComponent<HealthSystem>();

        if (enemy != null)
        {
            enemyHealth.AddDamage(_damageAmount);

            if (chargeCounter == 1)
            {
                Destroy(gameObject);
            }
        }
    }

    private void spellCharger()
    {

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
    }

}