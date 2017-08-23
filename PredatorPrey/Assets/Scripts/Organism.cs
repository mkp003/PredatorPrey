using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Organism class will represent the base attributes that all 'organisms' will contain.
/// </summary>
public class Organism : MonoBehaviour {

    // Base attributes contained by all organisms
    [SerializeField]
    private float health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int reproductionRate;

    // Prefab gameObject for the organism
    [SerializeField]
    private GameObject organismPrefab;


    private void Start()
    {
        // Reproduce every few seconds
        InvokeRepeating("Reproduce", 10.0f, 10.0f);

        // Change direction every few seconds
        InvokeRepeating("Movement", 0f, 20);
    }

    /// <summary>
    /// CreateOrganism() will set the base attributes of the current organism.
    /// </summary>
    /// <param name="health"></param>
    /// <param name="speed"></param>
    /// <param name="size"></param>
    public void CreateOrganism(float health, float speed, int reproductionRate, GameObject prefab)
    {
        this.health = health;
        this.speed = speed;
        this.reproductionRate = reproductionRate;
        this.organismPrefab = prefab;
    }

    /// <summary>
    /// GetOrganismHealth() will return the organisms health.
    /// </summary>
    /// <returns>this.health</returns>
    public float GetOrganismHealth()
    {
        return this.health;
    }


    /// <summary>
    /// GetOrganismSpeed() will return the organisms speed.
    /// </summary>
    /// <returns>this.speed</returns>
    public float GetOrganismSpeed()
    {
        return this.speed;
    }


    /// <summary>
    /// GetOrganismSize() will return the organisms size.
    /// </summary>
    /// <returns>this.reproductionRate</returns>
    public int GetOrganismReproductiveRate()
    {
        return this.reproductionRate;
    }


    /// <summary>
    /// Reproduce() will create a new organism exactly the same as the parent
    /// </summary>
    public void Reproduce()
    {
        GameObject progeny = Instantiate(this.organismPrefab, transform.position, transform.rotation);
    }


    /// <summary>
    /// Movement() will move the organism in a new direction.
    /// </summary>
    public void Movement()
    {
        //print("Movement occuring");
        float newX = Random.Range(-2.0f, 11.0f);
        float newY = Random.Range(-4.5f, 4.5f);
        Vector2 newLocation = new Vector2(newX, newY);
        transform.position = Vector2.MoveTowards(transform.position, newLocation, this.speed);
    }


    /// <summary>
    /// TakeDamage() will incure the specified damage to the current organism.
    /// </summary>
    /// <param name="damage">float value of the damage dealt</param>
    public void TakeDamage(float damage)
    {
        this.health = this.health - damage;
    }


    /// <summary>
    /// CheckDeath() will check to see if the current organism is dead. If so, 
    /// then the organism is removed from the simulation.
    /// </summary>
    public void CheckDeath()
    {
        if(this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
