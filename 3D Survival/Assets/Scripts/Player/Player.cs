using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This is the Player Class. This script only holds 
    data on the overall status of the player.
*/
public class Player : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    // public float speed;
    public float currentHunger;
    public float currentThirst;
    public float bodyTemp;
    public float energy;

    private void Start() {
        currentHealth = maxHealth;
    }
}
