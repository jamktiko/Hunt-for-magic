using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private AudioSource _audioSrc;

    [SerializeField]
    private bool _move;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            _move = true;
        }
        else
        {
            _move = false;
        }

        if (_move == true && _audioSrc.isPlaying == false)
        {
            Randomizer();
            _audioSrc.Play();
        }

        if (_move == false)
        {
            _audioSrc.Stop();
        }
    }

    void Randomizer()
    {
        _rnd = Random.Range(1, 11);

        switch (_rnd)
        {
            case 1:
                _audioSrc.clip = _runningOnGrass1;
                break;
            case 2:
                _audioSrc.clip = _runningOnGrass2;
                break;
            case 3:
                _audioSrc.clip = _runningOnGrass3;
                break;
            case 4:
                _audioSrc.clip = _runningOnGrass4;
                break;
            case 5:
                _audioSrc.clip = _runningOnGrass5;
                break;
            case 6:
                _audioSrc.clip = _runningOnGrass6;
                break;
            case 7:
                _audioSrc.clip = _runningOnGrass7;
                break;
            case 8:
                _audioSrc.clip = _runningOnGrass8;
                break;
            case 9:
                _audioSrc.clip = _runningOnGrass9;
                break;
            case 10:
                _audioSrc.clip = _runningOnGrass10;
                break;
        }
    }
}
