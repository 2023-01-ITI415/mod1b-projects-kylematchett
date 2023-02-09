using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent ( typeof(Renderer) )]
public class Goal : MonoBehaviour
{
	static public bool 	goalMet = false;

	void OnTriggerEnter(Collider other) {
		// when the trigger is hit by something
		// check to see if it's a Projectile 
		Projectile proj = other.GetComponent<Projectile>();
		if ( proj != null ) {
			// If so, set goalMet to true
			Goal.goalMet = true;
			// Also set the alpha of the color to higher opacity
			Material mat = GetComponent<Renderer>().material;
			// b
			Color c = mat.color;
			//c.a = 0.75f;
			c= new Color(0,0,255);
			mat.color = c;
		}
	}
	
}
