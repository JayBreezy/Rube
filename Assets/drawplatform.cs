using UnityEngine;
using System.Collections;

public class drawplatform : MonoBehaviour {

	Vector3 lastPoint = Vector3.one;

	public Transform progressBar;
	public Transform line;
	public Material gray;

	private Transform cube;
	private Vector3 newPoint;
	private Vector3 newSize;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)) {
			drawPlatform();
		}
		if(lastPoint.z != 1) transformLine();
	}

	void transformLine() {

		// Endpoint
		newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		newPoint.z = 0f;

		// Check if initial point exists
		if(lastPoint.z == 1) lastPoint = newPoint;

		// Put line center between endpoints
		cube.transform.position = (lastPoint + newPoint) / 2;

		// Get line length
		Vector3 difference = lastPoint - newPoint;

		// Get previous line length
		float oldSize = newSize.magnitude;

		// Create size for new line based on distance between endpoints
		newSize = Vector3.one * 0.25f;
		newSize.x = difference.magnitude;

		// Get change in lengths from last frame
		float deltaSize =  newSize.magnitude - oldSize;


		// Change the progress bar based on the the change in line size
		float actualDeltaSize = progressBar.GetComponent<BarScript>().changeSize(-1f * deltaSize);
		//print (deltaSize - actualDeltaSize);
		/*if(actualDeltaSize < deltaSize - 0.01) {
			//newSize.x = newSize.x + deltaSize - actualDeltaSize;
			print ("Too big or too small");
		}*/
		//print (deltaSize);

		// Adjust newSize to match actual change, which may be less than planned change if it hits min or max size
		//newSize.x -= deltaSize;

		// Update line object size and rotation
		cube.transform.localScale = newSize;	
		float angle = Mathf.Atan2(lastPoint.y - newPoint.y, lastPoint.x - newPoint.x) * Mathf.Rad2Deg;
		cube.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void drawPlatform()
	{	
		newSize = Vector3.zero;
		cube = Instantiate(line);
		transformLine();
		cube.GetComponent<Renderer>().GetComponent<Renderer>().material = gray;
		lastPoint = newPoint;
	}
}
