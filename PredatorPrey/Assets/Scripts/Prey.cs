using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : Organism {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
