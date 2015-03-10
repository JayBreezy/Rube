using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 * script for modifying and bookkeeping of limiting bars
 */
public class BarScript : MonoBehaviour {

	public float baseVal = 100f;
	public float curVal;
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
		//displayText.text = curVal.ToString();
	}



	public float changeSize(float delta) {

		if(delta + curVal > baseVal) { // Too big, exceeds max size
			float change = baseVal - curVal;
			ResetBar();
			return change;
		}
		else if(delta + curVal <= 0) { // Too small, size ends up less than zero
			float change = -1 * curVal;
			curVal = 0;
			transform.localScale = Vector3.zero;
			return change;
		}
		print ("standard");
		curVal += delta;
		Vector3 temp = transform.localScale;
		temp.x += delta * unitsPerPerc;
		transform.localScale = temp;
		return delta;
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
