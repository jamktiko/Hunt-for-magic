using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDebuffs : MonoBehaviour
{
    [SerializeField]
    private bool _isWet;

    [SerializeField]
    private bool _onFire;

    [SerializeField]
    private bool _chilled;

    [SerializeField]
    private bool _slowed;

    [SerializeField]
    private bool _oilSlowed;

    private PlayerCharacterController playerCC;
    private HealthSystem _playerHealth;
    private float _debuffDamage = 0.01f;
    public GameObject _fireDebuffImage;
    public GameObject _chilledDebuffImage;
    public GameObject _slowedDebuffImage;
    public GameObject _oilDebuffImage;
    public GameObject _wetDebuffImage;


    // Start is called before the first frame update
    void Start()
    {
        _onFire = false;
        playerCC = GetComponent<PlayerCharacterController>();
        _playerHealth = GetComponent<HealthSystem>();
        _fireDebuffImage.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_onFire)
        {
            StartCoroutine("FireDamage");
            _fireDebuffImage.SetActive(true);
        }
        if (_chilled)
        {
            playerCC.speed *= 0.5f; 
            StartCoroutine("ChillStopper");
            _chilledDebuffImage.SetActive(true);
        }
        if (_slowed)
        {
            StartCoroutine("SlowStopper");
            _slowedDebuffImage.SetActive(true);
        }
        if (_oilSlowed)
        {
            StartCoroutine("OilStopper");
            _oilDebuffImage.SetActive(true);
        }
        if (_isWet)
        {
            StartCoroutine("WetStopper");
            _wetDebuffImage.SetActive(true);
        }
    }
    IEnumerator FireDamage()
    {
        int i = 0;
        while (i < 5 && _onFire)
        {
            yield return new WaitForSeconds(1f);
            Repeat();
            i++;
        }
        _fireDebuffImage.SetActive(false);
        _onFire = false;
    }
    IEnumerator ChillStopper()
    {
        int i = 0;

        while (i < 8 && _chilled)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }
        playerCC.speed *= 1.5f;
        _chilledDebuffImage.SetActive(false);
        _chilled = false;
    }
    IEnumerator SlowStopper()
    {
        int i = 0;

        while (i < 8 && _slowed)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }
        _slowedDebuffImage.SetActive(false);
        _slowed = false;
    }
    IEnumerator OilStopper()
    {
        int i = 0;

        while (i < 4 && _oilSlowed)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }
        _oilDebuffImage.SetActive(false);
        _oilSlowed = false;
    }
    IEnumerator WetStopper()
    {
        int i = 0;
        while (i < 10 && _isWet)
        {
            yield return new WaitForSeconds(1f);
            i++;
        }
        _wetDebuffImage.SetActive(false);
        _isWet = false;
    }
    private void Repeat()
    {
        _playerHealth.AddDamage(_debuffDamage);
    }
}
