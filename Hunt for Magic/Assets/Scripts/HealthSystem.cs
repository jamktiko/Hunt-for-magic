using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;

    [SerializeField]
    public float _maxHealth;

    public float health => _health;

    public bool _damageTaken;

    public bool _deadSlime;

    public AudioSource _slimeSounds;
    public AudioSource _slimeAnim;
    public AudioClip _slimeDeath;
    public AudioClip _slimeDamage;

    public AudioSource _archerSounds;
    public AudioClip _archerDamage;
    public AudioClip _archerDeath;

    private bool _soundPlaying;

    [SerializeField]
    private GameObject _playerDamageTaken;
    public GameObject _player;

    public void AddDamage(float damage)
    {

        if (gameObject.tag == "Player" && gameObject.GetComponent<Dodgedash>()._dodgeDash)
        {
            damage = 0;
        }

            _health -= damage;

        if (gameObject.tag == "Player" && !gameObject.GetComponent<Dodgedash>()._dodgeDash)
        {
            if (!GameObject.FindWithTag("HUD").GetComponent<PlayerDebuffs>()._onFire)
            {
                _damageTaken = true;
            }

            _playerDamageTaken.SetActive(true);

            Invoke("DamageOff", 1f);
        }

        if (gameObject.name.Contains("EnemySlimePrefab") && !_slimeAnim.isPlaying && !gameObject.GetComponent<Debuffs>()._onFire)
        {
            _slimeAnim.PlayOneShot(_slimeDamage);
        }

        if (gameObject.name.Contains("EnemyArcher") && !_archerSounds.isPlaying && !gameObject.GetComponent<Debuffs>()._onFire)
        {
            _archerSounds.PlayOneShot(_archerDamage);
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

            if (gameObject.name.Contains("EnemyArcher"))
            {
                gameObject.GetComponent<EnemyArcherMovement>().enabled = false;

                if (!_soundPlaying)
                {
                    _archerSounds.PlayOneShot(_archerDeath);
                    _soundPlaying = true;
                }
            }

            if (gameObject.name.Contains("Vine"))
            {
                Destroy(gameObject);
            }

            if (gameObject.tag == "Monster" && !gameObject.name.Contains("Plantie"))
            {
                Destroy(gameObject, 2f);   //2 sekuntia aikaa kuolinanimaatiolle
            }
            else if (gameObject.name.Contains("Plantie"))
            {
                Destroy(gameObject, 10f);
            }
            else if (gameObject.tag == "Player")
            {
                GameObject.Find("Panel").GetComponent<GameOverScript>()._gameoverPanel.SetActive(true);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void AddHealth(float heal)
    {
        _health += heal;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void DamageOff()
    {
        _playerDamageTaken.SetActive(false);

        _damageTaken = false;
    }
}
