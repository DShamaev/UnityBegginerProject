using UnityEngine;
using System.Collections;

/// <summary>
/// Camera bounds.
/// Keep camera in (0,0):(mapX,mapY) boundaries
/// </summary>
public class CameraBounds : MonoBehaviour {

	public float mapSizeX = 100.0f;
	public float mapSizeY = 100.0f;
	
	private float minX ;
	private float maxX ;
	private float minY ;
	private float maxY ;
	
	void Start() {
		//orthographicSize is the Size parameter of the camera in sidebar in Unity Editor
		var vertExtent = Camera.main.camera.orthographicSize;    
		var horzExtent = vertExtent * Screen.width / Screen.height;
		
		// Calculations assume map is position at the origin
		minX = horzExtent - mapSizeX / 2.0f;
		maxX = mapSizeX / 2.0f - horzExtent;
		minY = vertExtent - mapSizeY / 2.0f;
		maxY = mapSizeY / 2.0f - vertExtent;
	}
	
	void LateUpdate() {
		var v3 = transform.position;

		//Mathf.Clamp limit first argument in boundaries of two others
		//Example: Mathf.Clamp(6,0,5) => 5

		//Limit camera position in boundaries of (minX,minY):(maxX,maxY)
		v3.x = Mathf.Clamp(v3.x, minX, maxX);
		v3.y = Mathf.Clamp(v3.y, minY, maxY);
		transform.position = v3;
	}
}
