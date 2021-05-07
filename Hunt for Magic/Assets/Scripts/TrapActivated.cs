using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivated : MonoBehaviour
{
    public GameObject _room;
    private float _startingPointX;
    private float _startingPointZ;

    // Start is called before the first frame update
    void Start()
    {
        _startingPointX = transform.position.x;
        _startingPointZ = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            if (_room.GetComponent<RoomEnter>()._roomActive && gameObject.transform.rotation.y == 0)
            {
                transform.position = new Vector3(Mathf.PingPong(Time.time * 8, 3) + _startingPointX, transform.position.y, transform.position.z);
            }
            else if (_room.GetComponent<RoomEnter>()._roomActive && gameObject.transform.rotation.y > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 8, 3) + _startingPointZ);
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
