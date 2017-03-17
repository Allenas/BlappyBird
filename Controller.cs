using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Bolun Gao

 */ 

public enum GameStates{
	Start,
	ReadyToPlay,
	Playing,
	GameOver,
	Pending,
}

public class Controller : MonoBehaviour {

	private GameStates state = GameStates.Start; 

	private int score;

	private float curTime;
	public float time;

	private Vector3 birdBeginPos;
	private Vector3 Pos;

	public Transform bird;

	public Text scoreText;

	// Use this for initialization
	void Start () {
		birdBeginPos = bird.position; 
		Pos = bird.position;
	}

	// Update is called once per frame
	void Update () {

		switch (state) {
		case GameStates.Start:{
				bird.position = birdBeginPos;
				state = GameStates.ReadyToPlay;

			}
			break;
		case GameStates.ReadyToPlay:{
				bird.position = birdBeginPos;
			}
			break;
		case GameStates.Playing:
			{
				scoreText.text  = " " + score + " " ;
			}
			break;
		case GameStates.GameOver:{
				curTime += Time.deltaTime;
				if (curTime > time) {
					curTime = 0;
					state = GameStates.Pending;
					gameReset ();
				}
			}
			break;
		case GameStates.Pending:{
				bird.position = birdBeginPos;
			}
			break;
		}

	}

	public GameStates getState(){
		return state;
	}

	public void toPlay(){
		state = GameStates.Playing;
		score = 0;
	}

	public void gameOver(){
		state = GameStates.GameOver;
	}

	private void gameReset(){

		bird.position = birdBeginPos; 

		PipeMovement[] tubes = (PipeMovement[]) FindObjectsOfType(typeof(PipeMovement));
		foreach (PipeMovement i in tubes) {
			i.gameObject.SetActive (false);
		}
	}

	public void addPoint(){
		score ++;
	}
}
