using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Organism class will represent the base attributes that all 'organisms' will contain.
/// </summary>
public class Organism : MonoBehaviour {

    //******Base attributes contained by all organisms
    // The health the organism contains
    [SerializeField]
    private float health;
    // The speed the organism can move
    [SerializeField]
    private float speed;
    // The rate at which an organism can reproduce
    [SerializeField]
    private int reproductionRate;
    // The rate an organism runs through it's energy
    [SerializeField]
    private float metabolism;
    // The amount of energy the organism has
    [SerializeField]
    private float energy;
    // Prefab gameObject for the organism
    [SerializeField]
    private GameObject organismPrefab;
    //******

    //******Dynamic attributes of each organism
    // Target Destination
    private Vector3 targetDestination;
    // The current health of each organism
    private float currentHealth;
    // The current energy of each organism
    private float currentEnergy;



    /// <summary>
    /// CreateOrganism() will set the base attributes of the current organism.
    /// </summary>
    /// <param name="health"></param>
    /// <param name="speed"></param>
    /// <param name="size"></param>
    public void CreateOrganism(float health, float speed, int reproductionRate, float metabolism, float energy, 
        GameObject prefab)
    {
        this.health = health;
        this.currentHealth = health;
        this.speed = speed;
        this.reproductionRate = reproductionRate;
        this.metabolism = metabolism;
        this.energy = energy;
        this.currentEnergy = energy;
        this.organismPrefab = prefab;
    }

    /// <summary>
    /// GetOrganismHealth() will return the organisms inital health.
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
    /// GetOrganismSize() will return the organism's reproductive rate.
    /// </summary>
    /// <returns>this.reproductionRate</returns>
    public int GetOrganismReproductiveRate()
    {
        return this.reproductionRate;
    }


    /// <summary>
    /// GetOrganismMetabolism() will return the metabolism of the organism
    /// </summary>
    /// <returns>this.metabolism</returns>
    public float GetOrganismMetabolism()
    {
        return this.metabolism;
    }


    /// <summary>
    /// GetOrganismEnergy() will return the inital energy value the organism has.
    /// </summary>
    /// <returns>this.energy</returns>
    public float GetOrganismEnergy()
    {
        return this.energy;
    }


    /// <summary>
    /// GetOrganismCurrentHealth() returns the organism's current health.
    /// </summary>
    /// <returns>this.currentHealth</returns>
    public float GetOrganismCurrentHealth()
    {
        return this.currentHealth;
    }


    /// <summary>
    /// GetOrganismCurrentEnergy() returns the organism's current energy.
    /// </summary>
    /// <returns>this.currentEnergy</returns>
    public float GetOrganismCurrentEnergy()
    {
        return this.currentEnergy;
    }


    /// <summary>
    /// GetTargetPosition() will return the organism's target destination
    /// </summary>
    /// <returns></returns>
    public Vector3 GetTargetPosition()
    {
        return this.targetDestination;
    }


    /// <summary>
    /// Reproduce() will create a new organism exactly the same as the parent.
    /// </summary>
    public void Reproduce()
    {
        GameObject progeny = Instantiate(this.organismPrefab, transform.position, transform.rotation);
        progeny.GetComponent<Organism>().CreateOrganism(this.health, this.speed, this.reproductionRate, 
            this.metabolism, this.energy, this.organismPrefab);
    }


    /// <summary>
    /// Movement() will move the organism in a new direction.
    /// </summary>
    public void Movement(Vector3 target)
    {
        // Move towards the new range
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*this.speed);
    }


    /// <summary>
    /// ChooseRandomDirection() will generate a random position for an organism to move.
    /// </summary>
    public void ChooseRandomDirection()
    {
        // Range within the simulation
        int newX = Random.Range(-2, 11);
        int newY = Random.Range(-5, 5);

        this.targetDestination = new Vector3(newX, newY, 1.0f);
    }


    /// <summary>
    /// TakeDamage() will incure the specified damage to the current organism.
    /// </summary>
    /// <param name="damage">float value of the damage dealt</param>
    public void TakeDamage(float damage)
    {
        this.currentHealth = this.currentHealth - damage;
    }


    /// <summary>
    /// EnergyLoss() will incure energy loss to the organism 
    /// </summary>
    public void EnergyLoss()
    {
        this.currentEnergy = this.currentEnergy - 0.1f;
    }


    /// <summary>
    /// CheckDeath() will check to see if the current organism is dead. If so, 
    /// then the organism is removed from the simulation. In order for an organism tp be 
    /// classified as dead, it must either have no health or energy left.
    /// </summary>
    public void CheckDeath()
    {
        if(this.currentHealth <= 0 || this.currentEnergy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
