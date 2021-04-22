using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject _gameoverPanel;

    [SerializeField]
    private Button _mainMenu;

    private GameObject _player;

    private GameObject _crosshair;

    public AudioSource _menuSrc;
    public AudioClip _menuClick;

    public GameObject[] SpellPickups;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _crosshair = GameObject.Find("Crosshair");

        _mainMenu.onClick.AddListener(MainMenu);

        SpellPickups = GameObject.FindGameObjectsWithTag("Pickup");
    }


    // Update is called once per frame
    void Update()
    {

        if (_gameoverPanel.activeSelf)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _player.GetComponent<PlayerCharacterController>().enabled = false;
        _player.GetComponentInChildren<PlayerAnimation>().enabled = false;
        _player.GetComponent<SpellCasting>().enabled = false;
        _player.GetComponent<PlayerSounds>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _crosshair.SetActive(false);

        foreach (GameObject spell in SpellPickups)
        {
            if (spell != null)
            {
                spell.GetComponent<PickupText>()._text.enabled = false;
            }
        }

        Time.timeScale = 0;
    }

    private void MainMenu()
    {
        _menuSrc.PlayOneShot(_menuClick);
        _gameoverPanel.SetActive(false);
        _player.GetComponent<PlayerCharacterController>().enabled = true;
        _player.GetComponentInChildren<PlayerAnimation>().enabled = true;
        _player.GetComponent<SpellCasting>().enabled = true;
        _player.GetComponent<PlayerSounds>().enabled = true;
        _crosshair.SetActive(true);

        foreach (GameObject spell in SpellPickups)
        {
            if (spell != null)
            {
                spell.GetComponent<PickupText>()._text.enabled = true;
            }
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
