using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMechanics : MonoBehaviour {

	public int score = 0;
	public int lives = 3;

	private Text text;

	// Use this for initialization
	void Start () {
		text = GameObject.Find ("Canvas").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lives <= 0) {
			Debug.Log ("Game has Ended!");
		}

		text.text = "Score:  " + score + "\nLives:   " + lives;
	}

	public void addScore(int scoreToAdd){
		score = score+scoreToAdd;
	}

	public void takeLife(){
		lives -= 1;
	}
	
}
