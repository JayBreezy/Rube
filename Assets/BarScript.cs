using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 * script for modifying and bookkeeping of limiting bars
 */
public class BarScript : MonoBehaviour {

	public float baseVal = 100f;
	float curVal;
	float xMax;
	float unitsPerPerc;
	public Text displayText;

	// Use this for initialization
	void Start () {
		xMax = transform.localScale.x;
		curVal = baseVal;
		unitsPerPerc = xMax / baseVal;
	}

	void FixedUpdate(){
		displayText.text = curVal.ToString();
	}

	/* 
	 * shrink the bar by percent
	 * will return 1 if unable to shrink by amount, else 0
	 */
	//TODO: fix return values
	public void ShrinkBar(float percent){

		if (percent > curVal)
			return;
			//return 1; UI buttons don't play nice with non void functions

		curVal -= percent;
		Vector3 temp = transform.localScale;
		temp.x -= percent * unitsPerPerc;
		transform.localScale = temp;

		return;
		//return 0;
	}

	/*
	 * adds to bar directly (can exceed 100%)
	 */
	public void GrowBar(float percent){
		curVal += percent;
		Vector3 temp = transform.localScale;
		temp.x += percent * unitsPerPerc;
		transform.localScale = temp;
	}

	/*
	 * reset bar to 100%
	 */
	public void ResetBar(){
		curVal = baseVal;
		Vector3 temp = transform.localScale;
		temp.x = xMax;
		transform.localScale = temp;
	}
	
	public float PercentLeft(){
		return curVal;
	}
}
