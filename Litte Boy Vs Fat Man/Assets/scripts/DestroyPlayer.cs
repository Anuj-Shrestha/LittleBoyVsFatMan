﻿using UnityEngine;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{
    public int health = 5;
    Text healthText;

    private void Start()
    {
        healthText = GameObject.Find("PlayerHealthText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Destroy();
        }

        healthText.text = "Health: " + health;
    }

    void Destroy()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            health--;
        }
        if (health < 1)
        {
            Destroy();
        }   
    }
}
