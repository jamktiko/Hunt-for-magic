﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    [SerializeField]
    public Object crystalUpgrade;
    public Object crystalUpgradeSlot;
    private Transform crystalFloat;
    private Transform crystalAnimation;
    public float fireBonus = 0f;
    public float waterBonus = 0f;
    public float airBonus = 0f;
    public float lightningBonus = 3f;
    public float chargeCount = 3f;
    public float fireDamage = 0.01f;
    public float meleeDamage = 5f;
    public float maxHp = 100f;
    private bool swapStats;

    // Start is called before the first frame update
    void Start()
    {
        crystalUpgrade = Resources.Load("Prefabs/EmptyUpgrade");
        crystalFloat = GameObject.Find("Crystal").GetComponent<Transform>();
        crystalAnimation = transform.Find("CrystalAnimationSphere");
        crystalAnimation.transform.position = crystalFloat.transform.position;       
    }

    // Update is called once per frame
    void Update()
    {
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

            if (crystalUpgradeSlot.name.Contains("Mountain"))
            {
                meleeDamage = 25f;
                maxHp = 125;
                var heal = 25;
                gameObject.GetComponent<HealthSystem>()._maxHealth = maxHp;
                gameObject.GetComponent<HealthSystem>().AddHealth(heal);
            }

            if (!crystalUpgradeSlot.name.Contains("Mountain"))
            {
                meleeDamage = 5f;
                maxHp = 100;
                gameObject.GetComponent<HealthSystem>()._maxHealth = maxHp;
            }

            swapStats = false;
        }
    }
}
