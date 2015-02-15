using UnityEngine;
using System.Collections;

public class Mammal:Animal {
	
	public static Animal Spawn(){
		Mammal instance = new Mammal ();
		return instance as Animal;
	}
	
	override public void Move (){
	}
	
	override public void ScanArea (){
	}
	
	override public void changeState (AnimalState newState){
	}
}