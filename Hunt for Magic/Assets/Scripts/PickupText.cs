using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupText : MonoBehaviour
{
    public Text _text;
    public GameObject _pickupPoint;
    public GameObject _pausePanel;
    public GameObject _settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponentInChildren<Text>();
        _pausePanel = GameObject.Find("PauseScreen");
        _settingsMenu = GameObject.Find("SettingsMenu");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var position = Camera.main.WorldToScreenPoint(_pickupPoint.transform.position);
        _text.gameObject.transform.position = position;

        if (position.z > 0 && position.z < 10)
        {
            _text.enabled = true;
        }
        else
        {
            _text.enabled = false;
        }
    }
}
