using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCharge : MonoBehaviour
{
    private GameObject _player;
    private TextMeshProUGUI _chargeText;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _chargeText = GetComponent<TextMeshProUGUI>();
        _chargeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.GetComponent<EnergySystem>()._currentEnergy < 100)
        {
            Debug.Log("100");
            _chargeText.enabled = true;
            _chargeText.text = _player.GetComponent<EnergySystem>()._currentEnergy.ToString();
        }
        else
        {
            _chargeText.enabled = false;
        }
    }
}
