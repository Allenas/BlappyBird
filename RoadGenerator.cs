using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadGenerator : MonoBehaviour {

	public List<GameObject> roadList;

	public GameObject road;

	private GameObject tempRoad;

	private float curRoadDitance;

	public float roadDistance;

	private int roadCount = 1;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < roadCount; i++) {

			tempRoad = Instantiate(road);
			roadList.Add (tempRoad);
			tempRoad.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		curRoadDitance += Time.deltaTime;
		if (curRoadDitance > roadDistance) {
			curRoadDitance = 0;
			generatorRoad ();
		}
	}

	private void generatorRoad(){

		for (int i = 0; i < roadCount; i++) {
			if (roadList [i].activeSelf == false && roadList [i] != null) {

				tempRoad = roadList [i];
				tempRoad.transform.position = new Vector3 (3.35f, -2.28f, 0);

				tempRoad.SetActive (true); 
				break;
			}
		}
	}
}
