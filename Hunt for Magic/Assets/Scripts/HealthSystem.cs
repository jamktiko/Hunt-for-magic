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

    public AudioClip _slimeDeath;

    private bool _soundPlaying;


    public void AddDamage(float damage)
    {
        if (gameObject.tag == "Player" && gameObject.GetComponent<Dodgedash>()._dodgeDash)
        {
            damage = 0;
        }

            _health -= damage;

        if (gameObject.tag == "Player")
        {
            _damageTaken = true;

            Invoke("DamageOff", 1f);
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

    private void DamageOff()
    {
        _damageTaken = false;
    }
}
