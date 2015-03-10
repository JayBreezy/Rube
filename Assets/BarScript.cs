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

	public void changeSize(float delta) {

		if(delta + curVal > baseVal) {
			ResetBar();
			return;
		}
		else if(delta + curVal < 0) {
			curVal = 0;
			transform.localScale = Vector3.zero;
		}

		curVal += delta;
		Vector3 temp = transform.localScale;
		temp.x += delta * unitsPerPerc;
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
