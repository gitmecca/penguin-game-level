using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Food Pickup Script

// Restores hunger, awards XP, plays a sound, and rotates the pickup.

public class addToHunger : MonoBehaviour

{

    [Header("Food Settings")]

    public int hungerRestoreAmount = 40;

    public int xpReward = 100;

    [Header("Visual Settings")]

    public float rotationSpeed = 90f;

    [Header("Audio")]

    public AudioSource collectSound;

    private void Update()

    {

        // Rotate the collectible

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)

    {

        // Only allow the player to collect the item

        if (other.CompareTag("Player"))

        {

            // Restore hunger

            playerManager.hunger += hungerRestoreAmount;

            // Award XP

            PlayerXP.lowXPPoints += xpReward;

            // Play pickup sound if assigned

            if (collectSound != null)

            {

                collectSound.Play();

            }

            Debug.Log("Food collected! Hunger +" + hungerRestoreAmount +

                      " | XP +" + xpReward);

            // Remove the pickup

            Destroy(gameObject);

        }

    }

}