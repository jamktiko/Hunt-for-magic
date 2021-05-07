using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _newGame;

    [SerializeField]
    private Button _exitGame;

    [SerializeField]
    private Button _settings;

    [SerializeField]
    private Button _logbook;

    public GameObject _settingsMenu;
    public GameObject _logBook;

    public AudioSource _menuSrc;
    public AudioClip _menuClick;

    // Start is called before the first frame update
    void Start()
    {
        _newGame.onClick.AddListener(NewGame);
        _logbook.onClick.AddListener(LogBook);
        _settings.onClick.AddListener(Setting);
        _exitGame.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NewGame()
    {
        int rnd = Random.Range(1, 3);

        _menuSrc.PlayOneShot(_menuClick);

        if (rnd == 1)
        {
            SceneManager.LoadScene(1);
        }

        else if (rnd == 2)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void LogBook()
    {
        _menuSrc.PlayOneShot(_menuClick);
        gameObject.SetActive(false);
        _logBook.SetActive(true);

    }

    private void Setting()
    {
        _menuSrc.PlayOneShot(_menuClick);
        gameObject.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    private void ExitGame()
    {
        _menuSrc.PlayOneShot(_menuClick);
        Application.Quit();
    }
}
