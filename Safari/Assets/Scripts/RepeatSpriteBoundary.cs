using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game
[RequireComponent (typeof (SpriteRenderer))]

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class RepeatSpriteBoundary : MonoBehaviour {
	SpriteRenderer sprite;

	/// <summary>Generated objects distribution in X axis</summary>
	public float horizontalDistribution = 1;
	
	/// <summary>Generated objects distribution in Y axis</summary>
	public float verticalDistribution = 1;
	
	/// <summary>Count of generated objects</summary>
	public int generationCount = 10;
	/// <summary>Array of objects prefabs</summary>
	public GameObject[] objectsPrefabs;
	
	/// <summary>Array of generated objects</summary>
	public GameObject[] generatedObjects;

	public GameObject[] gameObject;
	void Awake () {



		// Get the current sprite with an unscaled size
		sprite = GetComponent<SpriteRenderer>();
		Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

 		// Generate a child prefab of the sprite renderer
		GameObject childPrefab = new GameObject();
		SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
		childPrefab.transform.position = transform.position;
		//childSprite.sprite = gameObject[prefabIndex].transform.GetComponent<SpriteRenderer>().sprite;

		//gameObject.transform.GetComponent<SpriteRenderer>().sprite = Resources.Load("Resources/Textures");
			

 		// Loop through and spit out repeated tiles
		GameObject child;
		for (int i = 1; i<5; i++)  {
			for (int j= 1; j<5; j++){
				child = Instantiate (childPrefab) as GameObject;
				child.transform.position = transform.position + (new Vector3(spriteSize.x*i,spriteSize.y*j, +9));
				int prefabIndex = Random.Range(0, objectsPrefabs.Length);
				child.transform.GetComponent<SpriteRenderer>().sprite = gameObject[prefabIndex].transform.GetComponent<SpriteRenderer>().sprite;								

				child.transform.parent = transform;
			}
		}
		// Set the parent last on the prefab to prevent transform displacement
		//for (int i = 0, l = (int)Mathf.Round(sprite.bounds.size.y); i < l; i++) 
		childPrefab.transform.parent = transform;
		
		// Disable the currently existing sprite component since its now a repeated image
		sprite.enabled = false;
	}
}