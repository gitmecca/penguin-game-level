using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

// Collectible Item Script
// Original concept customized for your game
// Adds item to inventory, gives XP, plays sound, then removes collectible.

public class CollectMe : MonoBehaviour
{
    public bool inTrigger;

    public bool debugMode = false;

    public Item item;

    public AudioSource collectSound;

    public int xpReward = 450;

    public float rotationSpeed = 90f;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;

            if (debugMode == true)
            {
                Debug.Log("Picking up " + item.name);
            }

            Inventory.instance.Add(item);

            PlayerXP.highXPPoints += xpReward;

            if (collectSound != null)
            {
                collectSound.Play();
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}
