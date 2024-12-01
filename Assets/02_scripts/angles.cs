using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angles : MonoBehaviour
{
    private Rigidbody rigidBdy;

    [SerializeField] private float cooldown;
    private bool isCoolDownReady = true;

    [Header("Limit Rot")]
    public float maxZRot = 45f;
    public float minZRot = -45f;
    public float amount = 40f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBdy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");

        rigidBdy.AddTorque(transform.forward * h * amount);

        LimitRot();
    }

    private void LimitRot()
    {
        Vector3 playerEulerAngles = transform.rotation.eulerAngles;

        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minZRot, maxZRot);

        GetComponent<Transform>().rotation = Quaternion.Euler(playerEulerAngles);
    }

    /*void MakeRotation0()
    {
        if (isCoolDownReady)
        {
            object value = transform.localRotation(0f,0f,0f);
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
    }*/
}
