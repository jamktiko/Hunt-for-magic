using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLHIt : MonoBehaviour
{
    public bool clHit;
    private Vector3 scaleChange, positionChange;
    public Transform Target;
    public Transform thisRB;


    // Start is called before the first frame update
    void Start()
    {
        thisRB = gameObject.GetComponent<Transform>();
        clHit = false;
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(0.32f, 0.32f, 0.32f);
        positionChange = new Vector3(0, -0.078f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.localScale += scaleChange;
        gameObject.transform.position += positionChange;
        Destroy(gameObject, 3.8f);
    }

    //Find target
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            clHit = other.gameObject.GetComponent<EnemySlimeMovement>().clHit;          

            if (!clHit)
            {
                Target = other.gameObject.GetComponent<Transform>();
            }
            else if (clHit)
            {
            
            }
            else clHit = false;
        }      
    }
}
