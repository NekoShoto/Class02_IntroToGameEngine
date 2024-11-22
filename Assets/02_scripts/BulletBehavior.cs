using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] int damage = 1;

    [SerializeField] GameObject vfxToSpawn;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.LoseHealth(damage);
            }

            if (vfxToSpawn != null)
            {
                Instantiate(vfxToSpawn, transform.position, transform.rotation);
            }

            Debug.Log("Collision");
            Destroy(this.gameObject);
        }
    }
}
