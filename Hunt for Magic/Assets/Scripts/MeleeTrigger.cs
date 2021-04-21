using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrigger : MonoBehaviour
{
    [SerializeField]
    private float _playerDamage = 5f;

    [SerializeField]
    private float _plantieDamage = 10f;

    private GameObject _player;

    public AudioClip _hitSlime;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "MeleeTrigger")
        {
            if (other != null && other.gameObject.tag != "Player")
            {
                other.GetComponent<HealthSystem>().AddDamage(_playerDamage);

                _player.GetComponent<PlayerSounds>()._meleeSrc.PlayOneShot(_hitSlime);
            }
        }

        else if (gameObject.name == "MeleeHit")
        {
            if (other != null && other.tag == "Player")
            {
                other.GetComponent<HealthSystem>().AddDamage(_plantieDamage);
            }
        }
    }
}
