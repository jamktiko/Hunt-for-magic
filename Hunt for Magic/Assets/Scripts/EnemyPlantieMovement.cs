using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPlantieMovement : MonoBehaviour
{
    private GameObject _player;
    private int _attackRoll;
    private float _cooldownLength;
    private bool _cooldown;
    private bool _meleeAttack;
    private GameObject _poisonCloud;
    private GameObject _vine;
    private GameObject _HAMissile;
    public GameObject _meleeHit;
    public Transform _poisonPos1;
    public Transform _poisonPos2;
    public Transform _vinePos1;
    public Transform _vinePos2;
    public Transform _vinePos3;
    public Transform _HAPos1;
    public Transform _HAPos2;
    public Transform _HAPos3;
    public bool _attack1;
    public bool _attack2;
    public bool _attack3;
    public bool _attack4;
    private bool CLcooldownActive;
    public bool clHit;
    public GameObject _spawnManager;
    public GameObject _victoryPanel;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _poisonCloud = Resources.Load<GameObject>("Prefabs/PoisonCloud");
        _vine = Resources.Load<GameObject>("Prefabs/PlantieVine");
        _HAMissile = Resources.Load<GameObject>("Prefabs/PlantieHAPrefab"); ;
        _meleeHit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {
            if (clHit && !CLcooldownActive)
            {
                CLcooldownActive = true;
                StartCoroutine(CLcooldown());
            }
            
        }

        if (!_cooldown)
        {
            _attackRoll = Random.Range(1, 5);

            if (_attackRoll == 1)
            {
                _cooldown = true;
                _attack1 = true;
                Attack1();
            }

            if (_attackRoll == 2)
            {
                _cooldown = true;
                _attack2 = true;
                StartCoroutine(Attack2());
            }

            if (_attackRoll == 3)
            {
                _cooldown = true;
                _attack3 = true;
                StartCoroutine(Attack3());
            }

            if (_attackRoll == 4)
            {
                _cooldown = true;
                _attack4 = true;
                _meleeAttack = true;
                StartCoroutine(Attack4());
            }
        }

        if (!_meleeAttack)
        {
            gameObject.transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
        }
    }

    void Attack1()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            GameObject poison = Instantiate(_poisonCloud, _poisonPos1.position, _poisonPos1.rotation);
            Destroy(poison, 5f);
        }
        else if (rand == 2)
        {
            GameObject poison = Instantiate(_poisonCloud, _poisonPos2.position, _poisonPos2.rotation);
            Destroy(poison, 5f);
        }

        _cooldownLength = 4.5f;
        StartCoroutine(Cooldown());
    }

    IEnumerator Attack2()
    {
        if (_vinePos1 != null && _vinePos2 != null && _vinePos3 != null)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject vine1 = Instantiate(_vine, _vinePos1.position, _vinePos1.rotation);
            yield return new WaitForSeconds(1f);
            GameObject vine2 = Instantiate(_vine, _vinePos2.position, _vinePos2.rotation);
            yield return new WaitForSeconds(1f);
            GameObject vine3 = Instantiate(_vine, _vinePos3.position, _vinePos3.rotation);

            Destroy(vine1, 5f);
            Destroy(vine2, 5.5f);
            Destroy(vine3, 6f);

            _cooldownLength = 4f;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Attack3()
    {
        yield return new WaitForSeconds(0.8f);
        GameObject HAAttack1 = Instantiate(_HAMissile, _HAPos1.position, _HAPos1.rotation);
        yield return new WaitForSeconds(0.5f);
        GameObject HAAttack2 = Instantiate(_HAMissile, _HAPos2.position, _HAPos2.rotation);
        yield return new WaitForSeconds(0.2f);
        GameObject HAAttack3 = Instantiate(_HAMissile, _HAPos3.position, _HAPos3.rotation);
        _cooldownLength = 5f;
        StartCoroutine(Cooldown());
    }

    IEnumerator Attack4()
    {
        yield return new WaitForSeconds(2.5f);
        _meleeHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _meleeHit.SetActive(false);

        yield return new WaitForSeconds(0.4f);
        _meleeAttack = false;

        _cooldownLength = 2f;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownLength);

        _cooldown = false;

        _attack1 = false;
        _attack2 = false;
        _attack3 = false;
        _attack4 = false;
    }

    IEnumerator CLcooldown()
    {
        yield return new WaitForSeconds(2.6f);
        clHit = false;
        CLcooldownActive = false;
    }
    private void OnDestroy()
    {
        Time.timeScale = 0;
        _victoryPanel.SetActive(true);
        _player.GetComponent<PlayerCharacterController>().enabled = false;
        _player.GetComponentInChildren<PlayerAnimation>().enabled = false;
        _player.GetComponent<SpellCasting>().enabled = false;
        _player.GetComponent<PlayerSounds>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
