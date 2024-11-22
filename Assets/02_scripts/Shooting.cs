using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletToSpawn;
    [SerializeField] Transform muzleLocation;
    [SerializeField] private float cooldown;

    private bool isCoolDownReady = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0.25)
        {
            Debug.Log("Fired");
            LaunchBullet();
        }
        
    }

    void LaunchBullet()
    {
        if (isCoolDownReady)
        {
            Instantiate(bulletToSpawn, muzleLocation.position, muzleLocation.rotation);
            isCoolDownReady = false;
            //TODO: Add MuzzleVFX and SFX
            StartCoroutine("ResetCooldown");
        }
    }

    public IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        isCoolDownReady = true;
        yield return null;
    }
}
