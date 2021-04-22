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

    public Slider _soundSlider;

    public UnityEngine.Audio.AudioMixer _mixer;

    public string parameterName;

    public AudioSource _menuSrc;
    public AudioClip _menuClick;

    private void Awake()
    {
        float savedVolume = PlayerPrefs.GetFloat(parameterName, 1);
        SetVolume(savedVolume);
        _soundSlider.value = savedVolume;
        _soundSlider.onValueChanged.AddListener((float _) => SetVolume(_));
        _return.onClick.AddListener(Return);
        _sensitivity.onValueChanged.AddListener(ApplySensitivity);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_sensitivity)
        {
            _sensitivity.value = (PlayerCharacterController.mouseSensitivity - 1) / 8;
        }
    }

    void SetVolume(float _value)
    {
        _mixer.SetFloat(parameterName, ConvertToDecibel(_value / _soundSlider.maxValue));
        PlayerPrefs.SetFloat(parameterName, _value);
    }

    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }

    public void ApplySensitivity(float mouseSens)
    {
        mouseSens = (_sensitivity.value * 8) + 1;
        PlayerCharacterController.mouseSensitivity = mouseSens;
    }

    void Return()
    {
        _menuSrc.PlayOneShot(_menuClick);
        gameObject.SetActive(false);
        _menuUI.SetActive(true);
    }
}
