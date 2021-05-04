using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float _timer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _timer);
    }
}
