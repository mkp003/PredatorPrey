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

    // Target Destination
    private Vector3 targetDestination;

    private float currentHealth;



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
    /// GetTargetPosition() will return the organism's target destination
    /// </summary>
    /// <returns></returns>
    public Vector3 GetTargetPosition()
    {
        return this.targetDestination;
    }


    /// <summary>
    /// Reproduce() will create a new organism exactly the same as the parent
    /// </summary>
    public void Reproduce()
    {
        GameObject progeny = Instantiate(this.organismPrefab, transform.position, transform.rotation);
        progeny.GetComponent<Organism>().CreateOrganism(this.health, this.speed, this.reproductionRate, this.organismPrefab);
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
    /// 
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
