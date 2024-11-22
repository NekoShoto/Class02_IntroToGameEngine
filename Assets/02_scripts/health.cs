using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int currentHealth = 0;
    [SerializeField] int maxHealth = 5;

    [SerializeField] public bool isPlayer;
    [SerializeField] List<Image> images = new List<Image>();

    AudioSource hitSound;

    GameLoppHandler gameLoppHandler;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        gameLoppHandler = GameObject.Find("GameLoppHandler").GetComponent<GameLoppHandler>();
        gameLoppHandler.StartGame();
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
                if (currentHealth == 0)
                {
                    gameLoppHandler.FinishGame();
                }
            }
        }
        else
        {
            if (currentHealth >= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (hitSound != null)
        {
            hitSound.Play();
        }
        else
        {
            Debug.Log("Hit sound is missing");
        }

    }


    public void AddHealth(int heal)
    {
        currentHealth += heal;
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoseHealth(1);
        }
    }


}
