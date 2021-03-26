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

    public GameObject _settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        _newGame.onClick.AddListener(NewGame);
        _settings.onClick.AddListener(Setting);
        _exitGame.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Setting()
    {
        gameObject.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
