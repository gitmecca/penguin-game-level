using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player Manager Script

// Controls hunger, hunger bar, and player death.

public class playerManager : MonoBehaviour

{

    [Header("Hunger Settings")]

    public static int hunger = 500;

    public int maxHunger = 500;

    public int hungerLossAmount = 5;

    public float hungerLossRate = 1f;

    [Header("Player Settings")]

    public GameObject player;

    public string deathTriggerName = "isDead";

    [Header("UI")]

    public Slider hungerBar;

    private bool isDead = false;

    private void Start()

    {

        hunger = maxHunger;

        if (hungerBar != null)

        {

            hungerBar.maxValue = maxHunger;

            hungerBar.value = hunger;

        }

        InvokeRepeating("ReduceHunger", 1f, hungerLossRate);

    }

    private void ReduceHunger()

    {

        if (isDead)

        {

            return;

        }

        hunger -= hungerLossAmount;

        hunger = Mathf.Clamp(hunger, 0, maxHunger);

        UpdateHungerBar();

        if (hunger <= 30)

        {

            TriggerDeath();

        }

    }

    public void UpdateHungerBar()

    {

        if (hungerBar != null)

        {

            hungerBar.value = hunger;

        }

    }

    private void TriggerDeath()

    {

        isDead = true;

        if (player != null)

        {

            Animator playerAnimator = player.GetComponent<Animator>();

            if (playerAnimator != null)

            {

                playerAnimator.SetTrigger(deathTriggerName);

            }

        }

        Debug.Log("Player died from hunger.");

    }

}
