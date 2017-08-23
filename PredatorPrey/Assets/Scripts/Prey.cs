using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : Organism {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Change direction every few seconds
        InvokeRepeating("Movement", 0f, 2.0f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Predator")
        {
            this.TakeDamage(0.01f);
            this.CheckDeath();
        }
    }
}
