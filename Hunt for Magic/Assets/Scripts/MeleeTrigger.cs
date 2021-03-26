using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrigger : MonoBehaviour
{
    [SerializeField]
    private float _damage = 5f;

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
        if (other != null && other.gameObject.tag != "Player")
        {
            other.GetComponent<HealthSystem>().AddDamage(_damage);

            _player.GetComponent<PlayerSounds>()._meleeSrc.PlayOneShot(_hitSlime);
        }
    }
}
