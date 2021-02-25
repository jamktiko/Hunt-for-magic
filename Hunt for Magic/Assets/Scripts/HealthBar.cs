using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private static Image HealthBarImage;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = GetComponent<Image>();
        player = GameObject.Find("PlayerCharacter");
    }

    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount <0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }
    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }


    // Update is called once per frame
    void Update()
    {
        SetHealthBarValue(player.GetComponent<HealthSystem>().health / 100);
    }
}
