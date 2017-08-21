using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SimulationManager is a class responsable for setting all the inital parameters of the 
/// simulation, and acts as a pseudo controller.
/// </summary>
public class SimulationManager : MonoBehaviour {

    [SerializeField]
    private int numberOfPrey;

    [SerializeField]
    private int numberOfPredators;

    [SerializeField]
    private GameObject preyPrefab;

    [SerializeField]
    private GameObject predatorPrefab;

    [SerializeField]
    private Vector2 startPosition;

    [SerializeField]
    private float gameWidth;

    [SerializeField]
    private float gameHeight;


    // Use this for initialization
    void Start () {
        GenerateOrganisms(this.preyPrefab, this.numberOfPrey);
        GenerateOrganisms(this.predatorPrefab, this.numberOfPredators);
    }
	
	// Update is called once per frame
	void Update () {
        
    }


    /// <summary>
    /// GenerateOrganisms() will create the specified number and type of organism.
    /// </summary>
    /// <param name="organism">GameObject prefab of the organism to be created</param>
    /// <param name="number">int of the number of organisms to be made</param>
    public void GenerateOrganisms(GameObject organism, int number)
    {
        for(int i = 0; i < number; i++)
        {
            Instantiate(organism, CreateRandomPosition(), transform.rotation);
        }
    }


    /// <summary>
    /// CreateRandomPosition() will create a random position to spawn the inital 
    /// organisms position.
    /// </summary>
    /// <returns>Vector3 position of the organism</returns>
    public Vector3 CreateRandomPosition()
    {
        float newX = Random.Range(-7.0f, -3.0f);
        float newY = Random.Range(-1.0f, 4.0f);
        return new Vector3(newX, newY, 0f);
    }
}
