using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField] int currentHealth = 0;
    [SerializeField] int maxHealth = 5;

    [SerializeField] bool isPlayer;
    [SerializeField] List<Image> images = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void LoseHealth(int damage)
    {
        currentHealth -= damage;

        if (isPlayer)
        {
            if (currentHealth >= 0)
            {
                images[currentHealth].gameObject.SetActive(false);
            }
        }
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
