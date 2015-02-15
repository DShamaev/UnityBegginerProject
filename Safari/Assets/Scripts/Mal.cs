using UnityEngine;
using System.Collections;

public class Mammal:Animal {
	
	public static Mammal Spawn(){
		Mammal instance = null;
		return instance;
	}
	
	//animal already has position variable in this.transform.position
	//so we need move function
	public void Move ();
	
	public void ScanArea ();
	
	public void changeState (AnimalState newState);
}