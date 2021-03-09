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

    // Start is called before the first frame update
    void Start()
    {
        _enemy = _enemyHealth.GetComponentInParent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var position = Camera.main.WorldToScreenPoint(_enemyHealth.transform.position);
        transform.position = position;

        if (position.z > 0 && position.z < 20)
        {
            gameObject.GetComponent<Image>().enabled = true;
            _healthBarImage.enabled = true;
        }

        else
        {
            gameObject.GetComponent<Image>().enabled = false;
            _healthBarImage.enabled = false;

        }

        _healthBarImage.fillAmount = _enemy.health / 100;

        if (_enemy.health == 0)
        {
            Destroy(gameObject);
        }
    }
}
