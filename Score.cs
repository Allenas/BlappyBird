using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
 * Bolun Gao

 */
public class Score : MonoBehaviour {

	private int score;

	public Text scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text  = " " + score + " " ;
			
	}

	public void addPoint(){
		score ++;
	}

	public void resetScore(){
		score = 0;
	}

	public int getPoint(){
		return score;
	}
}
