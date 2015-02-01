using UnityEngine;
using System.Collections;

/// <summary>
/// Spawner.
/// Spawn GameObjects in some radius around spawner
/// </summary>
public class Spawner : MonoBehaviour {

	public float horizontalDistribution = 1;
	public float verticalDistribution = 1;
	public int TreeCount = 10;

	/// <summary>Array of objects prefabs.</summary>
	public GameObject[] treePrefabProvider;
	public GameObject[] treesArray;

	float x,y,z;
	
	void Spawn (int i)
	{
		//Generate random source for instance
		int enemyIndex = Random.Range(0, treePrefabProvider.Length);

		//Determine object spawn position
		Vector3 spawnPosition = new Vector3();
		while(true){
			spawnPosition = new Vector3 (x+Random.Range (-horizontalDistribution, horizontalDistribution), y+Random.Range (-verticalDistribution, verticalDistribution), z);
			if(isNotIntersectedWithOthers(i,enemyIndex,spawnPosition)){
				break;
			};
		};

		// Instantiate object.
		treesArray[i] = Instantiate(treePrefabProvider[enemyIndex], spawnPosition, transform.rotation) as GameObject;
		treesArray[i].transform.parent = transform.parent;
	}

	bool isNotIntersectedWithOthers(int size,int index, Vector3 pos){
		for (int i=0; i<size; i++) {
			Rect objectArea = new Rect(treesArray[i].transform.position.x-treesArray[i].renderer.bounds.size.x/2,
			                           treesArray[i].transform.position.x+treesArray[i].renderer.bounds.size.x/2,
			                           treesArray[i].transform.position.y-treesArray[i].renderer.bounds.size.y/2,
			                           treesArray[i].transform.position.y+treesArray[i].renderer.bounds.size.y/2);
			if(objectArea.Contains(pos)){
				return false;
			}
		}
		return true;
	}

	void Start ()
	{
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

		// Start calling the Spawn function repeatedly after a delay .
		//
		treesArray = new GameObject[TreeCount];
		for (int i=0; i<TreeCount; i++) {
			Spawn (i);
		}
	}
}