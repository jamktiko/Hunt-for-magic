using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;

    [SerializeField]
    public AudioSource _walkingSrc;

    [SerializeField]
    public AudioSource _spellSrc;

    public AudioSource _meleeSrc;

    public AudioSource _otherSrc;

    private bool _move;

    private bool _fire;

    public bool _dodgedash;

    private int _rnd;

    public AudioClip _runningOnGrass1;
    public AudioClip _runningOnGrass2;
    public AudioClip _runningOnGrass3;
    public AudioClip _runningOnGrass4;
    public AudioClip _runningOnGrass5;
    public AudioClip _runningOnGrass6;
    public AudioClip _runningOnGrass7;
    public AudioClip _runningOnGrass8;
    public AudioClip _runningOnGrass9;
    public AudioClip _runningOnGrass10;

    public AudioClip _flameThrower1;
    public AudioClip _flameThrower2;

    public AudioClip _melee1;

    public AudioClip _dodgedash1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _meleeSrc.clip = _melee1;

        if (GetComponent<CharacterController>().isGrounded && GetComponent<PlayerCharacterController>().speed == 2.5f && (Input.GetKey("w") | Input.GetKey("a") | Input.GetKey("s") | Input.GetKey("d")))
        {
            _move = true;
        }
        else
        {
            _move = false;
        }

        if (GetComponent<SpellCasting>()._spellPrefab != null && GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle" && Input.GetButton("Fire1") && GetComponent<EnergySystem>()._currentEnergy > 5)
        {
            _fire = true;
        }
        else
        {
            _fire = false;
        }

        if (_move == true && _walkingSrc.isPlaying == false)
        {
            WalkingRandomizer();
            _walkingSrc.Play();
        }

        if (_move == false)
        {
            _walkingSrc.Stop();
        }

        if (_dodgedash == true && _otherSrc.isPlaying == false)
        {
            _otherSrc.Play();
        }

        if (_dodgedash == false)
        {
            _otherSrc.Stop();
        }

        if (_fire == true && _spellSrc.isPlaying == false)
        {
            _rnd = Random.Range(1, 3);

            if (_rnd == 1)
            {
                _spellSrc.clip = _flameThrower1;
            }
            else if (_rnd == 2)
            {
                _spellSrc.clip = _flameThrower2;
            }

            _spellSrc.Play();
        }

        if (GetComponent<SpellCasting>()._spellPrefab != null && GetComponent<SpellCasting>()._spellPrefab.name == "Flamethrower_particle")
        {
            if (Input.GetButtonUp("Fire1") | GetComponent<EnergySystem>()._currentEnergy < 5)
            {
                _spellSrc.Stop();
            }
        }
    }

    void WalkingRandomizer()
    {
        _rnd = Random.Range(1, 11);

        switch (_rnd)
        {
            case 1:
                _walkingSrc.clip = _runningOnGrass1;
                break;
            case 2:
                _walkingSrc.clip = _runningOnGrass2;
                break;
            case 3:
                _walkingSrc.clip = _runningOnGrass3;
                break;
            case 4:
                _walkingSrc.clip = _runningOnGrass4;
                break;
            case 5:
                _walkingSrc.clip = _runningOnGrass5;
                break;
            case 6:
                _walkingSrc.clip = _runningOnGrass6;
                break;
            case 7:
                _walkingSrc.clip = _runningOnGrass7;
                break;
            case 8:
                _walkingSrc.clip = _runningOnGrass8;
                break;
            case 9:
                _walkingSrc.clip = _runningOnGrass9;
                break;
            case 10:
                _walkingSrc.clip = _runningOnGrass10;
                break;
        }
    }
}
