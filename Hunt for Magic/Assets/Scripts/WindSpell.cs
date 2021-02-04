using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour  //Tämä scripti liitetään Tuulispellin prefabiin
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
            enemy.AddForce(0, 1f, 2f, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
