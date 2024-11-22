using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    [SerializeField] float movementspeed = 15f;
    [SerializeField] float offsetToKill = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -1) * movementspeed * Time.deltaTime;
        if (transform.position.z < -offsetToKill)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.name);
            Health temp = collision.gameObject.GetComponent<Health>(); //temp means temporary is a funciont named by us
            if (temp != null)
            {
                temp.LoseHealth(1);
            }
            Destroy(this.gameObject);
        }
    }
}
