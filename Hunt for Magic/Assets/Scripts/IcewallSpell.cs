using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcewallSpell : MonoBehaviour
{
    [SerializeField]
    public float _damageAmount;
    private float _baseDamage = 20f;
    private float WaterBonus;

    [SerializeField]
    private float _speed = 35f;

    private Transform _castingPoint;

    private Transform _waterCastingPoint;

    private Object _iceWall;
    public GameObject _player;
    private Object _iceTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerCharacter");
        WaterBonus = _player.GetComponent<CrystalScript>().waterBonus;
        _damageAmount = _baseDamage = WaterBonus;
        _castingPoint = GameObject.Find("CastingPoint").GetComponent<Transform>();
        _waterCastingPoint = GameObject.Find("WaterCastingPoint").GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(_castingPoint.forward * _speed, ForceMode.Impulse);
        _iceTrigger = Resources.Load("Prefabs/Icewall_Trigger");
        _iceWall = Resources.Load("Prefabs/IcyWall");
    }

    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" || other.tag == "Wood")
        {
            Object damageTrigger = Instantiate(_iceTrigger, transform.position, Quaternion.identity);
            Object icewall = Instantiate(_iceWall, transform.TransformPoint(0, -1, 0), _waterCastingPoint.rotation);

            Destroy(damageTrigger, 1f);
            Destroy(icewall, 8f);

            Destroy(gameObject);
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject.GetComponentInParent<ParticleSystem>());
            Destroy(gameObject);
        }
    }
}
