using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudUpgrades : MonoBehaviour
{
    public GameObject _mountain;
    public GameObject _ember;
    public GameObject _north;
    public GameObject _tear;
    public GameObject _magnet;

    private GameObject _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.GetComponent<CrystalScript>().crystalUpgradeSlot != null)
        {
            if (_player.GetComponent<CrystalScript>().crystalUpgradeSlot.name.Contains("Mountain"))
            {
                _mountain.SetActive(true);
            }
            else
            {
                _mountain.SetActive(false);
            }

            if (_player.GetComponent<CrystalScript>().crystalUpgradeSlot.name.Contains("Ember"))
            {
                _ember.SetActive(true);
            }
            else
            {
                _ember.SetActive(false);
            }

            if (_player.GetComponent<CrystalScript>().crystalUpgradeSlot.name.Contains("North"))
            {
                _north.SetActive(true);
            }
            else
            {
                _north.SetActive(false);
            }

            if (_player.GetComponent<CrystalScript>().crystalUpgradeSlot.name.Contains("Tear"))
            {
                _tear.SetActive(true);
            }
            else
            {
                _tear.SetActive(false);
            }

            if (_player.GetComponent<CrystalScript>().crystalUpgradeSlot.name.Contains("Magnet"))
            {
                _magnet.SetActive(true);
            }
            else
            {
                _magnet.SetActive(false);
            }
        }
    }
}
