using UnityEngine;
using System.Collections;

/// <summary>
/// Spawner.
/// Spawn GameObjects in some radius around spawner
/// </summary>
public class Spawner : MonoBehaviour {

	public float horizontalDistribution = 1;
	public float verticalDistribution = 1;

	/// <summary>The amount of time between each spawn.</summary>
	public float spawnTime = 5f;

	/// <summary>The amount of time before spawning starts.</summary>
	public float spawnDelay = 3f;

	/// <summary>Array of objects prefabs.</summary>
	public GameObject[] enemies;

	float x,y,z;

	void Start ()
	{
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	void Spawn ()
	{
		//Determine object spawn position
		var spawnPosition = new Vector3 (x+Random.Range (-horizontalDistribution, horizontalDistribution), y+Random.Range (-verticalDistribution, verticalDistribution), z);

		//Select an object from array to instantiate
		int enemyIndex = Random.Range(0, enemies.Length);

		// Instantiate object.
		Instantiate(enemies[enemyIndex], spawnPosition, transform.rotation);
	}
}