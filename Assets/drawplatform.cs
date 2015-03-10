using UnityEngine;
using System.Collections;

public class drawplatform : MonoBehaviour {

	Vector3 lastPoint = Vector3.one;

	public Transform line;
	public Material gray;

	private Transform cube;
	private Vector3 newPoint;
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
		newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		newPoint.z = 0f;
		if(lastPoint.z == 1) lastPoint = newPoint;
		cube.transform.position = (lastPoint + newPoint) / 2;
		Vector3 difference = lastPoint - newPoint;
		Vector3 newSize = Vector3.one * 0.25f;
		newSize.x = difference.magnitude;
		cube.transform.localScale = newSize;
		float angle = Mathf.Atan2(lastPoint.y - newPoint.y, lastPoint.x - newPoint.x) * Mathf.Rad2Deg;
		cube.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void drawPlatform()
	{	
		cube = Instantiate(line);
		transformLine();
		cube.GetComponent<Renderer>().GetComponent<Renderer>().material = gray;
		lastPoint = newPoint;
	}
}
