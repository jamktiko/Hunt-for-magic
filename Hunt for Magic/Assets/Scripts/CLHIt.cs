using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLHIt : MonoBehaviour
{
    public bool firstHit;
    public bool clHit;
    private Vector3 scaleChange, positionChange;
    public GameObject Target;
    public GameObject _CLobject;
    private Rigidbody thisRB;


    // Start is called before the first frame update
    void Start()
    {
        _CLobject = GameObject.Find("ChainLightning");
        firstHit = true;
        clHit = false;
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(0.38f, 0.38f, 0.38f);
        positionChange = new Vector3(0, -0.082f, 0);
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
            clHit = other.gameObject.GetComponent<EnemySlimeMovement>().clHit;

            if (clHit || firstHit)
                {

                }

            if (!clHit && !firstHit)
            {
                Target = other.gameObject.GetComponent<GameObject>();

                if (Target != null)
                {
                    firstHit = true;
                    _CLobject.GetComponent<ChainLightingSpell>().target = Target;
                }
            }          
        }      
    }
}
