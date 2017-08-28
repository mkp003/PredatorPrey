using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : Organism {

    // Use this for initialization
    void Start()
    {
        // Change direction every few seconds
        InvokeRepeating("ChooseRandomDirection", 0f, 1.0f);

        // Reproduce every few seconds
        InvokeRepeating("Reproduce", 5.0f, (100.0f/this.GetOrganismReproductiveRate()));

        // Metabolism starts
        InvokeRepeating("EnergyLoss", 1.0f, (100.0f/this.GetOrganismMetabolism()));
    }

    // Update is called once per frame
    void Update()
    {
        Movement(this.GetTargetPosition());
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        // Within clutches of a predator
        if (collision.gameObject.tag == "Predator")
        {
            this.TakeDamage(0.01f);
            this.CheckDeath();
        }
    }
}
