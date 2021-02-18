using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetDebuff : MonoBehaviour
{
    [SerializeField]
    public bool _wet;

    // Update is called once per frame
    void Update()
    {
        if (_wet == true)
        {
            Invoke("WaterStopper", 5f);
        }
    }

    private void WaterStopper()
    {
        _wet = false;
    }
}
