using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour
{
    private GameObject _player;

    public GameObject _mainSpell;
    public GameObject _spellSlot1;
    public GameObject _spellSlot2;
    public Object _newSpell;
    public Object _spell0;
    public Object _spell1;
    public Object _spell2;
    public static int _activeSlot;
    private bool _active0;
    private bool _active1;
    private bool _active2;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _newSpell = _player.GetComponent<SpellCasting>()._spellPrefab;

        if (SpellPickup._count > 0)
        {
            if (SpellPickup._count == 1 && _mainSpell.activeSelf == false)
            {
                _mainSpell.SetActive(true);
                _spell0 = _newSpell;
            }
            else if (SpellPickup._count == 2 && _spellSlot1.activeSelf == false)
            {
                _spellSlot1.SetActive(true);
                _spell1 = _newSpell;
                _activeSlot = 1;
            }
            else if (SpellPickup._count == 3 && _spellSlot2.activeSelf == false)
            {
                _spellSlot2.SetActive(true);
                _spell2 = _newSpell;
                _activeSlot = 2;
            }
            else if (SpellPickup._count == 4 || SpellPickup._countAdded)
            {
                if (_activeSlot == 0)
                {
                    _spell0 = _newSpell;
                }
                if (_activeSlot == 1)
                {
                    _spell1 = _newSpell;
                }
                if (_activeSlot == 2)
                {
                    _spell2 = _newSpell;
                }
            }
            else
            {

            }

        }


        if (Input.GetKey("1"))
        {
            _active0 = true;
            _active1 = false;
            _active2 = false;
        }
        if (Input.GetKey("2"))
        {
            _active0 = false;
            _active1 = true;
            _active2 = false;
        }
        if (Input.GetKey("3"))
        {
            _active0 = false;
            _active1 = false;
            _active2 = true;
        }


        if (_active0 && _mainSpell.activeSelf == true)
        {
            _activeSlot = 0;
            _player.GetComponent<SpellCasting>()._spellPrefab = _spell0;
        }
        if (_active1 && _spellSlot1.activeSelf == true)
        {
            _activeSlot = 1;
            _player.GetComponent<SpellCasting>()._spellPrefab = _spell1;
        }
        if (_active2 && _spellSlot2.activeSelf == true)
        {
            _activeSlot = 2;
            _player.GetComponent<SpellCasting>()._spellPrefab = _spell2;
        }
    }
}

