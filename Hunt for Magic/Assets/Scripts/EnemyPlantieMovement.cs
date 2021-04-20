using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantieMovement : MonoBehaviour
{
    private GameObject _player;
    private int _attackRoll;
    private float _cooldownLength;
    private bool _cooldown;
    private bool _meleeAttack;
    private GameObject _poisonCloud;
    private GameObject _vine;
    public GameObject _meleeHit;
    public Transform _poisonPos1;
    public Transform _poisonPos2;
    public Transform _vinePos1;
    public Transform _vinePos2;
    public Transform _vinePos3;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _poisonCloud = Resources.Load<GameObject>("Prefabs/PoisonCloud");
        _vine = Resources.Load<GameObject>("Prefabs/PlantieVine");
        _meleeHit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_cooldown)
        {
            _attackRoll = Random.Range(1, 5);

            if (_attackRoll == 1)
            {
                Attack1();
                _cooldown = true;
            }

            if (_attackRoll == 2)
            {
                Attack2();
                _cooldown = true;

            }

            if (_attackRoll == 3)
            {
                Attack3();
                _cooldown = true;
            }

            if (_attackRoll == 4)
            {
                Attack4();
                _cooldown = true;
                _meleeAttack = true;
            }
        }

        if (!_meleeAttack)
        {
            gameObject.transform.LookAt(_player.transform.position);
        }
    }

    void Attack1()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            GameObject poison = Instantiate(_poisonCloud, _poisonPos1.position, Quaternion.identity);
            Destroy(poison, 5f);
        }
        else if (rand == 2)
        {
            GameObject poison = Instantiate(_poisonCloud, _poisonPos2.position, Quaternion.identity);
            Destroy(poison, 5f);
        }

        _cooldownLength = 4.5f;
        StartCoroutine(Cooldown());
    }

    void Attack2()
    {
        GameObject vine1 = Instantiate(_vine, _vinePos1.position, _player.transform.rotation);
        GameObject vine2 = Instantiate(_vine, _vinePos2.position, Quaternion.identity);
        GameObject vine3 = Instantiate(_vine, _vinePos3.position, Quaternion.identity);

        Destroy(vine1, 3.9f);
        Destroy(vine2, 3.7f);
        Destroy(vine3, 3.5f);

        _cooldownLength = 4f;
        StartCoroutine(Cooldown());
    }

    void Attack3()
    {
        _cooldownLength = 5f;
        StartCoroutine(Cooldown());
    }

    void Attack4()
    {
        StartCoroutine(Melee());

        _cooldownLength = 4.5f;
        StartCoroutine(Cooldown());
    }

    IEnumerator Melee()
    {
        yield return new WaitForSeconds(1.5f);
        _meleeHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _meleeHit.SetActive(false);

        yield return new WaitForSeconds(0.4f);
        _meleeAttack = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownLength);

        _cooldown = false;
    }
}
