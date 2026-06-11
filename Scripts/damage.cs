using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damage : MonoBehaviour {

   // public GameObject player;


    private void OnTriggerEnter(Collider other)

    {

         if (other.CompareTag("Player"))

    {

            healthSystem.health -= 70;

            PlayerXP.damageXPPenalty -= 40;

    }

}
