using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogVisibility : MonoBehaviour
{
    [SerializeField]
    private float _slimeRange = 5f;


    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("EnemySlimePrefab"))
        {
            other.GetComponent<EnemySlimeMovement>()._range = _slimeRange;
            yield return new WaitForSeconds(6.9f);
            other.GetComponent<EnemySlimeMovement>()._range = other.GetComponent<EnemySlimeMovement>()._maxRange;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("EnemySlimePrefab"))
        {
            other.GetComponent<EnemySlimeMovement>()._range = other.GetComponent<EnemySlimeMovement>()._maxRange;
        }
    }
}
