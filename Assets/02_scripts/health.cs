using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] int currentHealth = 0;
    [SerializeField] int maxHealth = 5;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void LoseHealth(int damage)
    {
        currentHealth -= damage;
        //todo add sound and gameplay logic to death
    }


    public void AddHealth(int heal)
    {
        currentHealth += heal;
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseHealth(1);
        }
    }
}
