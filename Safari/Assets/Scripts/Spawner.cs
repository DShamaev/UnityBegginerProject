﻿using UnityEngine;

/// <summary>
/// Spawner.
/// Spawn GameObjects in some radius around spawner
/// </summary>
public class Spawner : MonoBehaviour {

	/// <summary>Generated objects distribution in X axis</summary>
	public float horizontalDistribution = 1;

	/// <summary>Generated objects distribution in Y axis</summary>
	public float verticalDistribution = 1;

	/// <summary>Count of generated objects</summary>
	public int treesGenerationCount = 200;

	/// <summary>Count of generated animal objects</summary>
	public int animalGenerationCount = 20;

	/// <summary>Number of attempts before overlapping will be allow</summary>
	public int allowOverlapingAfter = 0;

	/// <summary>Array of objects prefabs</summary>
	public GameObject[] objectsPrefabs;

	/// <summary>Array of generated objects</summary>
	public GameObject[] generatedObjects;

	/// <summary>Array of animal prefabs</summary>
	public GameObject[] animalPrefabs;

	public enum ObjectType {
		PLANT,
		ANIMAL,
	};

	/// <summary>Coordinates of spawner</summary>
	float x,y,z = 0;

	/// <summary>If distance between spites lower then overlapping will be</summary>
	float overlappingRadius = 0;

	/// <summary>Counter for unsucessfull non-overlapping placements</summary>
	int unsuccessfulAttempts = 0;

	void Spawn (int i, ObjectType objectType)
	{
		//Select random prefab for instance
		int prefabIndex = Random.Range(0, objectType == ObjectType.ANIMAL ? animalPrefabs.Length : objectsPrefabs.Length);

		//Determine object spawn position
		//Trying to select non-overlapping position 
		//calculating distance from generated position to already generated position
		Vector3 spawnPosition = new Vector3();
		do{
			spawnPosition = new Vector3 (x+Random.Range (-horizontalDistribution, horizontalDistribution), y+Random.Range (-verticalDistribution, verticalDistribution), z);
		}while(!(isNotIntersectedWithOthers(i,spawnPosition) || (unsuccessfulAttempts>allowOverlapingAfter && allowOverlapingAfter!=0)));

	//	generatedObjects[i] = Instantiate(objectType == ObjectType.ANIMAL ? animalPrefabs[prefabIndex] : objectsPrefabs[prefabIndex], spawnPosition, transform.rotation) as GameObject;
	//	generatedObjects[i].transform.parent = transform.parent;


		if (objectType == ObjectType.ANIMAL) {
			Mammal mammal = Mammal.Spawn() as Mammal;
			mammal.instObject = generatedObjects[i];
			//add rigid body
		}
		generatedObjects [i] = Instantiate (objectType == ObjectType.ANIMAL ? animalPrefabs[prefabIndex] : objectsPrefabs [prefabIndex], spawnPosition, transform.rotation) as GameObject;
		generatedObjects[i].transform.parent = transform.parent;
	}

	bool isNotIntersectedWithOthers(int index, Vector3 pos){
		for (int i=0; i<index; i++) {
			if(Vector3.Distance(pos, generatedObjects[i].transform.position) < overlappingRadius){
				unsuccessfulAttempts++;
				return false;
			}
		}
		return true;
	}

	void Start ()
	{
		//Write spawner position
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

		//Determine overllaping radius
		//Approximate overllaping radius as highest _diameter_ of circumscribed circles around prefabs
		for (int i=0; i<objectsPrefabs.Length; i++) {
			var radius = Mathf.Sqrt(Mathf.Pow(objectsPrefabs[i].renderer.bounds.size.x,2)+Mathf.Pow(objectsPrefabs[i].renderer.bounds.size.y,2));
			if(overlappingRadius < radius){
				overlappingRadius = radius;
			}
		}

		// Spawn objects
		generatedObjects = new GameObject[treesGenerationCount];
		for (int i=0; i<treesGenerationCount; i++) {
			Spawn (i,ObjectType.PLANT);
		}

		for (int i=0; i<animalGenerationCount; i++) {
			Spawn (i,ObjectType.ANIMAL);
		}
	}
}