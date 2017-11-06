using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		//if(other.tag == "Enemy") { // change what it can hit later
			Movement movementScript = other.GetComponent<Movement>();
			movementScript.KnockBack();
		//}
	}
}
