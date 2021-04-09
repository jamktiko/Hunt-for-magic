using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private AudioSource _menuSrc;
    private AudioClip _pickup;
    public int _healthAmount;

    // Start is called before the first frame update
    void Start()
    {
        _menuSrc = GameObject.Find("HUD").GetComponent<AudioSource>();
        _pickup = Resources.Load<AudioClip>("SFX/Player/Spells/spell_pickup");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _menuSrc.PlayOneShot(_pickup);
            other.GetComponent<HealthSystem>().AddHealth(_healthAmount);
            Destroy(gameObject);
        }
    }
}
