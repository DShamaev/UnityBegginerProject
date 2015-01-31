using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.

	//FIXME: unhardcode variables
	public float xMin = 0;
	public float xMax = 1;
	public float yMin = 0;
	public float yMax = 1;
	public float z    = 4;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		transform.position = new Vector3 (Random.Range (xMin, xMax), Random.Range (xMin, xMax), z);
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
	}
}