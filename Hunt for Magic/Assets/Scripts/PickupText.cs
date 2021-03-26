using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupText : MonoBehaviour
{
    public GameObject _text;
    public GameObject _pickupPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var position = Camera.main.WorldToScreenPoint(_pickupPoint.transform.position);
        _text.transform.position = position;

        if (position.z > 0 && position.z < 10)
        {
            _text.SetActive(true);
        }
        else
        {
            _text.SetActive(false);
        }
    }
}
