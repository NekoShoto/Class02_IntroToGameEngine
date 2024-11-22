using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveX;
    private float moveY;

    [SerializeField] private float moveSpeed = 4f;
    private Rigidbody rigidBdy;

    // Start is called before the first frame update
    void Start()
    {
        rigidBdy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        
        Vector3 moveDir = new Vector3(moveX, moveY, 0);
        rigidBdy.AddForce(moveDir * moveSpeed * Time.deltaTime);

       if (moveX > 0)
        {
          
        }
    }
}
