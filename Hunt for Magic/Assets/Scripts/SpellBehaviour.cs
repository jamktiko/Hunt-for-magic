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
        if (SpellPickup._count < 99)
        {
            Pickup();
        }

        if (Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey(KeyCode.E))
        {
            Inputs();
            _player.GetComponent<SpellCasting>()._spellPrefab = _newSpell;
        }

        if (_active0 || _active1 || _active2 || Input.GetKeyDown(KeyCode.E))
        {
            ActiveSlots();
        }
    }

    private void Pickup()
    {
        if (SpellPickup._count == 1 && _mainSpell.activeSelf == false)
        {
            _mainSpell.SetActive(true);
            _spell0 = _newSpell;
        }
        else if (SpellPickup._count == 2 && _spellSlot1.activeSelf == false)
        {
            _spellSlot1.SetActive(true);
            _activeSlot = 1;
            _spell1 = _newSpell;

        }
        else if (SpellPickup._count == 3 && _spellSlot2.activeSelf == false)
        {
            _spellSlot2.SetActive(true);
            _activeSlot = 2;
            _spell2 = _newSpell;
            _active0 = false;
            _active1 = false;
            _active2 = true;
        }
        else
        {

        }
    }

    private void Inputs()
    {
        if (Input.GetKeyDown("1"))
        {
            _active0 = true;
            _active1 = false;
            _active2 = false;

            _newSpell = _spell0;
        }
        else if (Input.GetKeyDown("2"))
        {
            _active0 = false;
            _active1 = true;
            _active2 = false;

            _newSpell = _spell1;
        }
        else if (Input.GetKeyDown("3"))
        {
            _active0 = false;
            _active1 = false;
            _active2 = true;

            _newSpell = _spell2;
        }
    }

    private void ActiveSlots()
    {
        if (_active0 && _mainSpell.activeSelf == true)
        {
            _activeSlot = 0;

            if (_spellSlot2.activeSelf)
            {
                _spell0 = _player.GetComponent<SpellCasting>()._spellPrefab;
            }
        }
        else if (_active1 && _spellSlot1.activeSelf == true)
        {
            _activeSlot = 1;

            if (_spellSlot2.activeSelf)
            {
                _spell1 = _player.GetComponent<SpellCasting>()._spellPrefab;
            }
        }
        else if (_active2 && _spellSlot2.activeSelf == true)
        {
            _activeSlot = 2;

            if (_spellSlot2.activeSelf)
            {
                _spell2 = _player.GetComponent<SpellCasting>()._spellPrefab;
            }
        }
    }
}
