using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel;

    [SerializeField]
    private Button _resume;

    [SerializeField]
    private Button _mainMenu;

    private GameObject _player;

    private GameObject _crosshair;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        _crosshair = GameObject.Find("Crosshair");

        _resume.onClick.AddListener(ContinueGame);

        _mainMenu.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.P))
        {
            if (!_pausePanel.activeSelf)
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        _pausePanel.SetActive(true);
        _player.GetComponent<PlayerCharacterController>().enabled = false;
        _player.GetComponentInChildren<PlayerAnimation>().enabled = false;
        _player.GetComponent<PlayerSounds>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _crosshair.SetActive(false);
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        _pausePanel.SetActive(false);
        _player.GetComponent<PlayerCharacterController>().enabled = true;
        _player.GetComponentInChildren<PlayerAnimation>().enabled = true;
        _player.GetComponent<PlayerSounds>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _crosshair.SetActive(true);
        Time.timeScale = 1;
    }

    private void MainMenu()
    {
        _pausePanel.SetActive(false);
        _player.GetComponent<PlayerCharacterController>().enabled = true;
        _player.GetComponentInChildren<PlayerAnimation>().enabled = true;
        _player.GetComponent<PlayerSounds>().enabled = true;
        _crosshair.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
