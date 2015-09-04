using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour {

	public int worth = 1;
	public GameObject particles;

	private GameMechanics gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindWithTag ("Mechanics").GetComponent<GameMechanics> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "Player") {
			gm.addScore(worth);
			Instantiate(particles, transform.position, transform.rotation);

			Destroy(this.gameObject);
		}
	}
}
