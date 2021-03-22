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

    // Start is called before the first frame update
    void Start()
    {
        _newGame.onClick.AddListener(NewGame);

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

    private void ExitGame()
    {
        Application.Quit();
    }
}
