using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	public GameObject spawnPoint;

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "Player") {
			GameObject.FindWithTag ("Mechanics").GetComponent<GameMechanics> ().takeLife ();
			c.gameObject.transform.position = spawnPoint.transform.position;
		} else {
			Destroy (c.gameObject);
		}
	}
}
