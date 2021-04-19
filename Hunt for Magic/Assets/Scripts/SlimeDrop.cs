using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDrop : MonoBehaviour
{
    private bool _dropCooldown;
    private bool _dropChargeCooldown;
    private Object _slowingSlime;
    private Object _ChargeSlime;
    public bool isChargeAttacking = false;
    public bool animationReady;

    // Start is called before the first frame update
    void Start()
    {
        _dropCooldown = false;
        _slowingSlime = Resources.Load("Prefabs/SlowingSlime");
        _ChargeSlime = Resources.Load("Prefabs/SlowingSlimeCharge");
    }

    // Update is called once per frame
    void Update()
    {
        isChargeAttacking = gameObject.GetComponent<EnemySlimeMovement>().isChargeAttacking;

        animationReady = gameObject.GetComponent<EnemySlimeMovement>().animationReady;

        if (!isChargeAttacking)
        {

        }
        else if (isChargeAttacking && _dropChargeCooldown == false && animationReady)
        {
            _dropChargeCooldown = true;

            Instantiate(_ChargeSlime, transform.TransformPoint(0, -0.50f, 0), Quaternion.identity);

            Invoke("ChargeCooldown", 3f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wood") && _dropCooldown == false)
        {
            _dropCooldown = true;

            Instantiate(_slowingSlime, transform.TransformPoint(0, -0.67f, 0), Quaternion.identity);

            Invoke("Cooldown", 6f);
        }
    }

    private void Cooldown()
    {
        _dropCooldown = false;
    }
    private void ChargeCooldown()
    {
        _dropChargeCooldown = false;
    }
}
