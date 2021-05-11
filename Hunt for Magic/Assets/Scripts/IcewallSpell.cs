using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcewallSpell : MonoBehaviour
{
    [SerializeField]
    public float _damageAmount;
    private float _baseDamage = 20f;
    private float WaterBonus;
    private float WindBonus;

    [SerializeField]
    private float _speed = 35f;

    private Transform _castingPoint;

    private Transform _waterCastingPoint;

    private Object _iceWall;
    public GameObject _player;
    private Object _iceTrigger;

    private GameObject _barrelExplosion;
    private GameObject _groundFire;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        WaterBonus = _player.GetComponent<CrystalScript>().waterBonus;
        WindBonus = _player.GetComponent<CrystalScript>().airBonus;
        _damageAmount = _baseDamage + WaterBonus + WindBonus;
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
        _iceTrigger = Resources.Load("Prefabs/Icewall_Trigger");
        _iceWall = Resources.Load("Prefabs/IcyWall");
        _barrelExplosion = Resources.Load<GameObject>("Prefabs/BarrelExplosion");
        _groundFire = Resources.Load<GameObject>("Prefabs/ground_on_fire");
    }

    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" || other.tag == "Wood")
        {
            Object damageTrigger = Instantiate(_iceTrigger, transform.position, Quaternion.Euler(0, _player.transform.rotation.eulerAngles.y, 0));
            Object icewall = Instantiate(_iceWall, transform.TransformPoint(0, -1, 0), Quaternion.Euler(0, _player.transform.rotation.eulerAngles.y + 270, 0));

            Destroy(damageTrigger, 1f);
            Destroy(icewall, 8f);

            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }

        if (other.name.Contains("Barrel"))
        {
            Instantiate(_barrelExplosion, other.transform.position, Quaternion.identity);
            Instantiate(_groundFire, other.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(other.gameObject);
            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }
    }
}
