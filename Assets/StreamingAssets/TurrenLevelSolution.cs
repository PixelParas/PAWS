using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class AimControl : MonoBehaviour
{

Turrent turrent;

void Start(){
   GameObject _t = GameObject.Find("WeponControl");
   turrent = _t.GetComponent<Turrent>();
}

void Update(){
//turrent has a public Variable aimTarget
//target is a Vector3 and can be accessed using the dot operator
	
//Use the .aimTowards(Vector 3 pos) Function to aim at the target
//The turrent automatically shoots at 3 second intervals
//Since the Game is in prototype phase there still isnt a win condition
// This is a proof of concept of Just in Time C# compilation at runtime

//Use the green button to compile
//Happy coding!
//turrent.aimTowards(turrent.aimTarget);


}

}