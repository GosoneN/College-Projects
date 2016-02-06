using UnityEngine;
using System.Collections;

public class Projectile_Behavior : MonoBehaviour {

	GameObject player;
//	float lifetime = 1.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible(){
	//	gameObject.SetActive (false);
		Destroy(gameObject);
	}

/*
	void Awake()
	{
		Destroy(gameObject, lifetime);
	}
*/

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Obstacle"){
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
