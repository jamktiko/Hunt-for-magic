using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    [SerializeField]
    public Object crystalUpgrade;
    public Object crystalUpgradeSlot;
    private Transform crystalFloat;
    private Transform crystalAnimation;
    public float fireBonus;
    public float waterBonus;
    public float airBonus;
    public float lightningBonus;
    public float chargeCount;
    public float fireDamage;
    private bool swapStats = true;

    // Start is called before the first frame update
    void Start()
    {
        crystalFloat = GameObject.Find("Crystal").GetComponent<Transform>();
        crystalAnimation = transform.Find("CrystalAnimationSphere");
        crystalAnimation.transform.position = crystalFloat.transform.position;
        crystalUpgradeSlot = crystalUpgrade;
        swapStats = false;
    }

    // Update is called once per frame
    void Update()
    {
        crystalAnimation.transform.position = crystalFloat.transform.position;

        if (crystalUpgrade != crystalUpgradeSlot)
        {
            crystalUpgradeSlot = crystalUpgrade;
            swapStats = true;
        }

        if (swapStats) 
        {
            if (crystalUpgradeSlot.name.Contains("Ember"))
            {
                fireBonus = 5f;
                fireDamage = 0.0115f;
            }

            if (!crystalUpgradeSlot.name.Contains("Ember"))
            {
                fireBonus = 0f;
                fireDamage = 0.01f;
            }

            if (crystalUpgradeSlot.name.Contains("Magnet"))
            {
                lightningBonus = 5f;
                chargeCount = 5f;
            }

            if (!crystalUpgradeSlot.name.Contains("Magnet"))
            {
                lightningBonus = 3f;
                chargeCount = 3f;
            }

            if (crystalUpgradeSlot.name.Contains("Tear"))
            {
                waterBonus = 5f;
            }

            if (!crystalUpgradeSlot.name.Contains("Tear"))
            {
                waterBonus = 0f;
            }

            if (crystalUpgradeSlot.name.Contains("North"))
            {
                airBonus = 5f;
            }

            if (!crystalUpgradeSlot.name.Contains("North"))
            {
                airBonus = 0f;
            }

            swapStats = false;
        }
    }
}
