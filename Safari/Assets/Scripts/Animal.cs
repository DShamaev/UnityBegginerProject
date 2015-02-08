using UnityEngine;
using System.Collections;

public abstract class Animal {

	public GameObject instObject; //var for game object

	public enum AnimalState{
		IDLE, //do nothing
		MOVING,
	};

	protected Vector3 directionVector; // will be used for scanning and movement
	protected AnimalState currentState;

	//function for instantiation and adding to scene
	//will have same implementation in parent
	//similar to GetInstance
	public static Animal Spawn(){
		Animal instance = null;
		return instance;
	}

	//animal already has position variable in this.transform.position
	//so we need move function
	public abstract void Move ();

	public abstract void ScanArea ();

	public abstract void changeState (AnimalState newState);
}
