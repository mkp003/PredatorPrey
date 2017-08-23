using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : Organism {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Change direction every few seconds
        InvokeRepeating("Movement", 0f, 2.0f);
    }

}
