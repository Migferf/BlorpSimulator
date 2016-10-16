using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerExit(Collider other)
    {
        Rigidbody2D blorp = other.gameObject.GetComponent<Rigidbody2D>();
        blorp.velocity = -blorp.velocity;
    }
}
