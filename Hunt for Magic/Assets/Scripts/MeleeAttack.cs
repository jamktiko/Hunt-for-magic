using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public bool _isAttackOnCooldown;

    public bool _soundTrigger;

    [SerializeField]
    public float _damage;
    public GameObject _player;
    public float _cooldown = 1.16f;

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private GameObject _meleeTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        
        _isAttackOnCooldown = false;
        _meleeTrigger.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            if (_isAttackOnCooldown)
                return;

            _damage = _player.GetComponent<CrystalScript>().meleeDamage;
            GetComponentInParent<PlayerSounds>()._meleeSrc.Play();

            _anim.SetTrigger("Melee");

            StartCoroutine(Attack());

            _isAttackOnCooldown = true;
            Invoke("EndAttackCooldown", _cooldown);
        }
    }

    void EndAttackCooldown()
    {
        _isAttackOnCooldown = false;

        GetComponentInParent<PlayerSounds>()._meleeSrc.Stop();
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.3f);

        _meleeTrigger.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        _meleeTrigger.SetActive(false);
    }
}