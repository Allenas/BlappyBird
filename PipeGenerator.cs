using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Bolun Gao

 */

public class PipeGenerator : MonoBehaviour {

	private Controller controller;

	public List<GameObject> pipeList;

	public GameObject pipe;

	private float randomHeight;

	private float curPipeDitance;
	public float pipeDistance;

	public float maxPipeHeight;
	public float minPipeHeight;



	public int pipeCount;

	// Use this for initialization
	void Start () {
	
		controller = (Controller) FindObjectOfType(typeof(Controller));
		for (int i = 0; i < pipeCount; i++) {

			GameObject tempPipe = (GameObject) Instantiate(pipe);
			pipeList.Add (tempPipe);
			tempPipe.SetActive (false);
		}
		curPipeDitance = pipeDistance;

	}
	
	// Update is called once per frame
	void Update () {
		if (controller.getState () != GameStates.Playing) {
			return;
		}
		curPipeDitance += Time.deltaTime;
		if (curPipeDitance > pipeDistance) {
			curPipeDitance = 0;
			generator ();
		}
	}

	private void generator(){
		randomHeight = Random.Range (minPipeHeight, maxPipeHeight);
		GameObject tempPipe = null;
		for (int i = 0; i < pipeCount; i++) {
			if (pipeList [i].activeSelf == false) {

				tempPipe = pipeList [i];
				break;
			}
		}

		if (pipeList != null) {

			tempPipe.transform.position = new Vector3 (transform.position.x, randomHeight, transform.position.z);
			tempPipe.SetActive (true); 
		}
	}
}
