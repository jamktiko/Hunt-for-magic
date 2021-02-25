using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDrop : MonoBehaviour
{
    private bool _dropCooldown;

    private Object _slowingSlime;

    // Start is called before the first frame update
    void Start()
    {
        _dropCooldown = false;
        _slowingSlime = Resources.Load("Prefabs/SlowingSlime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && _dropCooldown == false)
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
}
