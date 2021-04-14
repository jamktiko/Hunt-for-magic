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
    private float fireBonus;
    private float waterBonus;
    private float airBones;
    private float lightningBonus;

    // Start is called before the first frame update
    void Start()
    {
        crystalFloat = GameObject.Find("Crystal").GetComponent<Transform>();
        crystalAnimation = transform.Find("CrystalAnimationSphere");
        crystalAnimation.transform.position = crystalFloat.transform.position;
        crystalUpgradeSlot = crystalUpgrade;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        crystalAnimation.transform.position = crystalFloat.transform.position;

        if (crystalUpgrade != crystalUpgradeSlot)
        {
            crystalUpgradeSlot = crystalUpgrade;
        }

        if (crystalUpgradeSlot.name.Contains("Ember") && crystalUpgradeSlot != null)
        {
            var changeScript = GameObject.Find("Fireball").GetComponent<FireballSpell>();
            if (changeScript != null)
            {
                changeScript._damageAmount = 10;
            }
        }
        if (!crystalUpgradeSlot.name.Contains("Ember") && crystalUpgradeSlot != null)
        {
            var changeScript = GameObject.Find("Fireball").GetComponent<FireballSpell>();
            if (changeScript != null)
            {
                changeScript._damageAmount = 5;
            }
        }

        if (crystalUpgradeSlot.name.Contains("Magnet") && crystalUpgradeSlot != null)
        {
            
            var changeScript = GameObject.Find("Electricity").GetComponent<LightingSpell>();
            changeScript._damageAmount = 20;
            var changeScript2 = GameObject.Find("LightningBolt").GetComponent<LightingBoltSpell>();
            if (!changeScript2)
            {
                changeScript2._boostAmount = 7;
                gameObject.GetComponent<SpellCasting>().maxAmmo = 5;
            }
        }
        if (!crystalUpgradeSlot.name.Contains("Magnet") && crystalUpgradeSlot != null)
        {
            var changeScript = GameObject.Find("Electricity").GetComponent<LightingSpell>();
            if (changeScript != null)
            {
                gameObject.GetComponent<SpellCasting>().maxAmmo = 3;
                changeScript._damageAmount = 15;
            }
            var changeScript2 = GameObject.Find("LightningBolt").GetComponent<LightingBoltSpell>();
            if (changeScript2 != null)
            {
                changeScript2._boostAmount = 3;
            }
        }

        if (crystalUpgradeSlot.name.Contains("Tear") && crystalUpgradeSlot != null)
        {
            var changeScript = GameObject.Find("WaterWave").GetComponent<WaterSpell>();
            if (changeScript != null)
            {
                changeScript._damageAmount = 13;
            }
        }
        if (!crystalUpgradeSlot.name.Contains("Tear") && crystalUpgradeSlot != null)
        {
            var changeScript = GameObject.Find("WaterWave").GetComponent<WaterSpell>();
            if (changeScript != null)
            {
                changeScript._damageAmount = 8;
            }
        }

        if (crystalUpgradeSlot.name.Contains("North") && crystalUpgradeSlot != null)
        {
            var changeScript = GameObject.Find("WindEffect").GetComponent<WindSpell>();
            if (changeScript != null)
            {
                changeScript._damageAmount = 20;
            }
        }
        if (!crystalUpgradeSlot.name.Contains("North") && crystalUpgradeSlot != null)
        {
            var changeScript = GameObject.Find("WindEffect").GetComponent<WindSpell>();
            if (changeScript != null)
            {  
                changeScript._damageAmount = 15;
            }
        }
    }

}
