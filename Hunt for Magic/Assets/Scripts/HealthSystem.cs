using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;

    [SerializeField]
    public float _maxHealth = 100;

    public float health => _health;

    public bool _damageTaken;

    public bool _deadSlime;

    public AudioSource _slimeSounds;

    public AudioSource _slimeAnim;

    public AudioClip _slimeDeath;

    public AudioClip _slimeDamage;

    private bool _soundPlaying;

    [SerializeField]
    private GameObject _playerDamageTaken;


    public void AddDamage(float damage)
    {
        if (gameObject.tag == "Player" && gameObject.GetComponent<Dodgedash>()._dodgeDash)
        {
            damage = 0;
        }

            _health -= damage;

        if (gameObject.tag == "Player" && !gameObject.GetComponent<Dodgedash>()._dodgeDash)
        {
            _damageTaken = true;

            _playerDamageTaken.SetActive(true);

            Invoke("DamageOff", 1f);
        }

        if (gameObject.name.Contains("EnemySlimePrefab") && !_slimeAnim.isPlaying && !gameObject.GetComponent<Debuffs>()._onFire)
        {
            _slimeAnim.PlayOneShot(_slimeDamage);
        }

        if (_health <= 0)
        {
            _health = 0;

            if (gameObject.name.Contains("EnemySlimePrefab"))
            {
                _deadSlime = true;
                gameObject.GetComponent<EnemySlimeMovement>().enabled = false;

                if (!_soundPlaying)
                {
                    _slimeSounds.PlayOneShot(_slimeDeath);
                    _soundPlaying = true;
                }
            }

            if (gameObject.tag != "Player")
            {
                Destroy(gameObject, 2f);   //2 sekuntia aikaa kuolinanimaatiolle
            }
            else
            {
                GameObject.Find("Panel").GetComponent<GameOverScript>()._gameoverPanel.SetActive(true);
            }
        }
    }

    public void AddHealth(float heal)
    {
        _health += heal;

        if (_health > 100)
        {
            _health = 100;
        }
    }

    private void DamageOff()
    {
        _playerDamageTaken.SetActive(false);

        _damageTaken = false;
    }
}
