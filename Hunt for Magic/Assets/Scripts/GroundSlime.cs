using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlime : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerDebuffs>()._slowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerDebuffs>()._slowEnding = true;
        }
    }
}
