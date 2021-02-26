using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestroy : MonoBehaviour
{
    private Transform _castingPoint;
    private float speed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * speed, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        if (enemy != null && enemy.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
}
