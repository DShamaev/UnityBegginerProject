using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float speed = 5000.0f;
	void Update()
	{
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3(speed * Time.deltaTime,0,0);
		}
		else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			transform.position += new Vector3(-speed * Time.deltaTime,0,0);
		}
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			transform.position += new Vector3(0,-speed * Time.deltaTime,0);
		}
		else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			transform.position += new Vector3(0,speed * Time.deltaTime,0);
		}
	}
}
