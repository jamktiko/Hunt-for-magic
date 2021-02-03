using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Rigidbody>();

        if (enemy != null)
        {
            enemy.AddForce(0, 0.5f, 1f, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
