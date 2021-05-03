using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField]
    private Image _healthBarImage;

    [SerializeField]
    private GameObject _enemyHealth;

    private HealthSystem _enemy;

    [SerializeField]
    private Image _wet;

    [SerializeField]
    private Image _fire;

    [SerializeField]
    private Image _chill;

    [SerializeField]
    private Image _oil;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = _enemyHealth.GetComponentInParent<HealthSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var position = Camera.main.WorldToScreenPoint(_enemyHealth.transform.position);
        transform.position = position;

        if (position.z > 0 && position.z < 20)
        {
            gameObject.GetComponent<Image>().enabled = true;
            _healthBarImage.enabled = true;

            if (gameObject.GetComponentInParent<Debuffs>()._wet)
            {
                _wet.enabled = true;
            }

            else
            {
                _wet.enabled = false;
            }

            if (gameObject.GetComponentInParent<Debuffs>()._onFire)
            {
                _fire.enabled = true;
            }

            else
            {
                _fire.enabled = false;
            }

            if (gameObject.GetComponentInParent<Debuffs>()._chilled)
            {
                _chill.enabled = true;
            }

            else
            {
                _chill.enabled = false;
            }

            if (gameObject.GetComponentInParent<Debuffs>()._oily)
            {
                _oil.enabled = true;
            }

            else
            {
                _oil.enabled = false;
            }
        }

        else
        {
            gameObject.GetComponent<Image>().enabled = false;
            _healthBarImage.enabled = false;
            _wet.enabled = false;
            _fire.enabled = false;
            _chill.enabled = false;
            _oil.enabled = false;
        }

        _healthBarImage.fillAmount = _enemy.health / _enemy._maxHealth;

        if (_enemy.health == 0)
        {
            Destroy(gameObject);
        }
    }
}
