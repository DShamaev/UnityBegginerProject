using UnityEngine;
using System.Collections;

/// <summary>
/// Spawner.
/// Spawn GameObjects in some radius around spawner
/// </summary>
public class Spawner : MonoBehaviour {

	public float horizontalDistribution = 1;
	public float verticalDistribution = 1;
	public float TreeCount = 10;

	/// <summary>Array of objects prefabs.</summary>
	public GameObject[] enemies;

	float x,y,z;
	
	void Spawn (int i)
	{
		//Determine object spawn position
		var spawnPosition = new Vector3 (x+Random.Range (-horizontalDistribution, horizontalDistribution), y+Random.Range (-verticalDistribution, verticalDistribution), z);

		int enemyIndex = Random.Range(0, enemies.Length);

		// Instantiate object.
		GameObject tree = Instantiate(enemies[enemyIndex], spawnPosition, transform.rotation) as GameObject;
		tree.transform.parent = transform.parent;
	}

	void Start ()
	{
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

		// Start calling the Spawn function repeatedly after a delay .
		//
		for (int i=0; i<TreeCount; i++) {
			Spawn (i);
		}
	}
}