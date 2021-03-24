using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPickup : MonoBehaviour
{
    public static int _count;

    public static bool _countAdded;

    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_countAdded == true)
        {
            _countAdded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_count > 3)
            {
                _countAdded = true;
            }

            if (gameObject.name == "Air_pickup")
            {
                _count += 1;
                other.GetComponent<SpellCasting>()._spellPrefab = Resources.Load("Prefabs/WindEffect");
                Destroy(gameObject);
            }

            if (gameObject.name == "Water_pickup")
            {
                _count += 1;
                other.GetComponent<SpellCasting>()._spellPrefab = Resources.Load("Prefabs/Waterwave");
                Destroy(gameObject);
            }

            if (gameObject.name == "Elec_Pickup")
            {
                _count += 1;
                other.GetComponent<SpellCasting>()._spellPrefab = Resources.Load("Prefabs/Electricity");
                Destroy(gameObject);
            }

            if (gameObject.name == "flamethrower_pickup")
            {
                _count += 1;
                other.GetComponent<SpellCasting>()._spellPrefab = Resources.Load("Prefabs/Flamethrower_particle");
                Destroy(gameObject);
            }

            if (gameObject.name == "Fireball_pickup")
            {
                _count += 1;
                other.GetComponent<SpellCasting>()._spellPrefab = Resources.Load("Prefabs/Fireball");
                Destroy(gameObject);
            }

            if (gameObject.name == "Lightningbolt_pickup")
            {
                _count += 1;
                other.GetComponent<SpellCasting>()._spellPrefab = Resources.Load("Prefabs/LightningBolt");
                Destroy(gameObject);
            }

            if (gameObject.name == "Chainlightning_pickup")
            {
                _count += 1;
                other.GetComponent<SpellCasting>()._spellPrefab = Resources.Load("Prefabs/ChainLightning");
                Destroy(gameObject);
            }
        }
    }
}
