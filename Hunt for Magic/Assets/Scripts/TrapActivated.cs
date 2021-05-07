using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivated : MonoBehaviour
{
    public GameObject _room;
    private float _startingPoint;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _startingPoint = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_room.GetComponent<RoomEnter>()._roomActive)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 5, 3) + _startingPoint, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthSystem>().AddDamage(25f);
        }
    }
}
