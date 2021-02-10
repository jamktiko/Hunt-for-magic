using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAI : MonoBehaviour
{
    public float radius;
    public float angle;
    public LayerMask Player;
    public LayerMask Obstacle;
    public LayerMask Monster;
    public LayerMask Hazard;

    public List<Transform> visibleTarget = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindTargetWithDelay(2f));
    }

    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTarget.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, radius, Player);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, distanceToTarget, Obstacle))
                {
                    visibleTarget.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees = Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees = Mathf.Deg2Rad));
    }
}