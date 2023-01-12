using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRb; // Rigid body for our target objects

    // Variables for our values..
    private float minSpeed = 13;
    private float maxSpeed = 19;
    private float maxTorque = 9;
    private float xRange = 5;
    private float ySpawnPos = 3;

    // Get reference to the GameManager script..
    private GameManager gameManager;

    // Point Assigned to each object
    public int pointValue;

    // Particle Explosion variable
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); // Then we initialize the rigid body here    

        targetRb.AddForce(RandomForce(), ForceMode.Impulse); // This adds force to our objects that sents it flying above.
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque()); // Since we have our force to fly upwards, this will rotate the object while flying.

        transform.position = RandomSpawnPos(); // Then we'll set out objects' new position to the given coordinates..   

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Then initalize the gamemanager script here
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() // On a click of a mouse we destroy the gameobject,
    {
        if (gameManager.isGameActive) // As long as game is active we can play..
        {
            Destroy(gameObject);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); // when we click on the object an explosion particle is activated

            gameManager.UpdateScore(pointValue); // and score updates by 1..
        }
        
    }

    private void OnTriggerEnter(Collider other) // When object enters sensor, object is destroyed.. & score deducts by 1
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")) // If sensor detects any object without the tag "Bad", game is over..
        {
            gameManager.GameOver();
        }

    }

    Vector3 RandomForce() // Random Force Values
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() // Random Torque Values
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos() // Random Spawn Positions
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }
}
