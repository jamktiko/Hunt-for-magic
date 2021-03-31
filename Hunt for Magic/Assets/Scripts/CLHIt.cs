using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLHIt : MonoBehaviour
{
    public bool firstHit;
    public bool clHit;
    private Vector3 scaleChange, positionChange;
    public Rigidbody Target;
    private Rigidbody thisRB;


    // Start is called before the first frame update
    void Start()
    {
        firstHit = true;
        clHit = false;
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(0.28f, 0.28f, 0.28f);
        positionChange = new Vector3(0, -0.052f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += scaleChange;
        gameObject.transform.position += positionChange;
        Destroy(gameObject, 1.8f);
    }

    //Find target
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            if (other.name.Contains("Slime"))
            {
                other.gameObject.GetComponent<EnemySlimeMovement>().clHit = true;
            }
            if (other.name.Contains("Archer"))
            {
                other.gameObject.GetComponent<EnemyArcherMovement>().clHit = true;
            }

            if (clHit || firstHit)
                {

                }

                if (!clHit && !firstHit)
                {
                    Target = other.gameObject.GetComponent<Rigidbody>();

                    if (Target != null)
                    {
                        firstHit = true;
                    }
                }          
        }      
    }
}
