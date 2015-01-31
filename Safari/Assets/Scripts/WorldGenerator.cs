using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		const int TREE_COUNT = 10; // count of visible trees after launch
		const int WATER_POOL_COUNT = 5; // count of water pools

		var vertExtent = Camera.main.camera.orthographicSize;    
		var horzExtent = vertExtent * Screen.width / Screen.height;
		Sprite sprite = null;
		Texture2D newPicture = null;
		System.Random r = new System.Random();
		SpriteRenderer renderer = gameObject.GetComponent("SpriteRenderer") as SpriteRenderer;
		//for (int i=0; i<TREE_COUNT; i++) {

			newPicture = Resources.Load<Texture2D>("Backgrounds/TileBackground");
			sprite = new Sprite();
		sprite = Sprite.Create(newPicture, new Rect(0, 0, 100, 100),new Vector2(Random.Range (horzExtent, horzExtent), Random.Range(-vertExtent, vertExtent)),100.0f);
			renderer.sprite = sprite;
		//}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
