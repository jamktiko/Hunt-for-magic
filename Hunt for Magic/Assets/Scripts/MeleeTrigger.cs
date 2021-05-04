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

    private GameObject _barrelExplosion;
    private GameObject _groundFire;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _barrelExplosion = Resources.Load<GameObject>("Prefabs/BarrelExplosion");
        _groundFire = Resources.Load<GameObject>("Prefabs/ground_on_fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "MeleeTrigger")
        {
            if (other != null && other.gameObject.tag == "Monster")
            {
                other.GetComponent<HealthSystem>().AddDamage(_playerDamage);

                _player.GetComponent<PlayerSounds>()._meleeSrc.PlayOneShot(_hitSlime);
            }
            else if (other != null && other.gameObject.name.Contains("Barrel"))
            {
                Instantiate(_barrelExplosion, other.transform.position, Quaternion.identity);
                Instantiate(_groundFire, other.transform.position, Quaternion.Euler(90, 0, 0));
                Destroy(other.gameObject);
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
