using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public Object crystalUpgrade;
    private Object crystalUpgradeSlot;
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
    void Update()
    {
        crystalAnimation.transform.position = crystalFloat.transform.position;

        if (crystalUpgrade != crystalUpgradeSlot)
        {
            crystalUpgradeSlot = crystalUpgrade;
        }

        if (crystalUpgradeSlot.name.Contains("Ember"))
        {
            var changeScript = GameObject.Find("Fireball").GetComponent<FireballSpell>();
            changeScript._damageAmount = 10;
        }
        else if (!crystalUpgradeSlot.name.Contains("Ember"))
        {
            var changeScript = GameObject.Find("Fireball").GetComponent<FireballSpell>();
            changeScript._damageAmount = 5;
        }

        if (crystalUpgradeSlot.name.Contains("Magnet"))
        {
            gameObject.GetComponent<SpellCasting>().maxAmmo = 5;
            var changeScript = GameObject.Find("Electricity").GetComponent<LightingSpell>();
            changeScript._damageAmount = 20;
            var changeScript2 = GameObject.Find("LightningBolt").GetComponent<LightingBoltSpell>();
            changeScript2._boostAmount = 7;
        }
        else if (!crystalUpgradeSlot.name.Contains("Magnet"))
        {
            gameObject.GetComponent<SpellCasting>().maxAmmo = 3;
            var changeScript = GameObject.Find("Electricity").GetComponent<LightingSpell>();
            changeScript._damageAmount = 15;
            var changeScript2 = GameObject.Find("LightningBolt").GetComponent<LightingBoltSpell>();
            changeScript2._boostAmount = 3;
        }

        if (crystalUpgradeSlot.name.Contains("Tear"))
        {
            var changeScript = GameObject.Find("WaterWave").GetComponent<WaterSpell>();
            changeScript._damageAmount = 13;
        }
        else if (!crystalUpgradeSlot.name.Contains("Tear"))
        {
            var changeScript = GameObject.Find("WaterWave").GetComponent<WaterSpell>();
            changeScript._damageAmount = 8;
        }

        if (crystalUpgradeSlot.name.Contains("North"))
        {
            var changeScript = GameObject.Find("WindEffect").GetComponent<WindSpell>();
            changeScript._damageAmount = 20;
        }
        else if (!crystalUpgradeSlot.name.Contains("North"))
        {
            var changeScript = GameObject.Find("WindEffect").GetComponent<WindSpell>();
            changeScript._damageAmount = 15;
        }
    }

}
