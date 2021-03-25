using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Button _return;

    [SerializeField]
    private GameObject _menuUI;

    public Slider _sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        _return.onClick.AddListener(Return);
        _sensitivity.onValueChanged.AddListener(ApplySensitivity);

        if (_sensitivity)
        {
            _sensitivity.value = (PlayerCharacterController.mouseSensitivity - 1) / 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Return()
    {
        gameObject.SetActive(false);
        _menuUI.SetActive(true);
    }

    public void ApplySensitivity(float mouseSens)
    {
        mouseSens = (_sensitivity.value * 8) + 1;
        PlayerCharacterController.mouseSensitivity = mouseSens;
    }
}
