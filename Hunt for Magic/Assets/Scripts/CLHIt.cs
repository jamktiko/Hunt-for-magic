using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLHIt : MonoBehaviour
{
    public bool clHit;
    private Vector3 scaleChange, positionChange;
    public Transform Target;
    public Transform thisRB;
    public GameObject CL;


    // Start is called before the first frame update
    void Start()
    {
        
        thisRB = gameObject.GetComponent<Transform>();
        clHit = false;
        gameObject.GetComponent<SphereCollider>();
        scaleChange = new Vector3(0.32f, 0.32f, 0.32f);
        positionChange = new Vector3(0, -0.078f, 0);
        Destroy(gameObject, 2.6f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        gameObject.transform.localScale += scaleChange;
        gameObject.transform.position += positionChange;      
    }

    //Find target
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            if (other.gameObject.name.Contains("Slime"))
            {
                clHit = other.gameObject.GetComponent<EnemySlimeMovement>().clHit;
            }
            else if (other.gameObject.name.Contains("Archer"))
            {
                clHit = other.gameObject.GetComponent<EnemyArcherMovement>().clHit;
            }
            else if (other.gameObject.name.Contains("Plantie"))
            {
                clHit = other.gameObject.GetComponent<EnemyPlantieMovement>().clHit;
            }

            if (!clHit)
            {
                Target = other.gameObject.GetComponent<Transform>();

                if (Target != null)
                {
                    CL = GameObject.FindWithTag("ChainLightning");
                    if (CL != null)
                    {
                        CL.GetComponent<ChainLightingSpell>().target = Target;
                        Destroy(gameObject);
                    }
                    
                }
            }
            else if (clHit)
            {
            
            }
            else clHit = false;
            
        }      
    }
}
