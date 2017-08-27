using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : Organism {

	// Use this for initialization
	void Start () {
        // Change direction every few seconds
        //InvokeRepeating("Movement", 1f, 2.0f);
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
    }

}
