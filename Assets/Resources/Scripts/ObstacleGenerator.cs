using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleGenerator : MonoBehaviour {

	public float minXrange;
	public float maxXrange;
	public float minYrange;
	public float maxYrange;
	public float minDist;
	public int numGenerate;
	List<Vector3> obstaclePos;

	// Use this for initialization
	void Start () {
		obstaclePos = new List<Vector3>();
		Random.seed = (int)System.DateTime.Now.Ticks;
		Vector3 potLoc;

		for (int i = 0; i < numGenerate; ++i) {
			do {potLoc = new Vector3 (Random.Range (minXrange, maxXrange), Random.Range (minYrange, maxYrange), 0f);} while (!validLocation(potLoc));
			GameObject cube = ((GameObject)Instantiate (Resources.Load ("Prefabs/Obstacle")));
			cube.transform.position = potLoc;
			obstaclePos.Add (potLoc);
		}
	
	}


	bool validLocation(Vector3 potLoc){
		if (obstaclePos.Count == 0) {return true;}
		foreach (Vector3 existingObst in obstaclePos) {
			if (Vector3.Distance (potLoc, existingObst) < minDist) {return false;}
		}
		return true;
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
