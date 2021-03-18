using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLHIt : MonoBehaviour
{
    public bool firstHit;
    public bool clHit;
    private Vector3 scaleChange, positionChange;
    public Rigidbody Target;


    // Start is called before the first frame update
    void Start()
    {
        firstHit = true;
        clHit = false;
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(0.08f, 0.08f, 0.08f);
        positionChange = new Vector3(0, -0.008f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += scaleChange;
        gameObject.transform.position += positionChange;
        Destroy(gameObject, 1.5f);
    }

    //Find target
    void OnTriggerEnter(Collider other)
    {      
        var enemy = other.gameObject.GetComponent<EnemySlimeMovement>().clHit;
        var target = other.gameObject.GetComponent<Rigidbody>();

        clHit = enemy;

        if (clHit)
        {

        }
        else if (!clHit && !firstHit)
        {
            firstHit = true;
            Target = target;
        }
    }
}
