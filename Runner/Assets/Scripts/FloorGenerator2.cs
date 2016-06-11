using UnityEngine;
using System.Collections;

public class FloorGenerator2 : MonoBehaviour {

	public GameObject cube, obstacle;
	public Camera camera;
	private float scrollspeed = 0.03f;
	private float stepsize = 4f;
	private Vector3 startPosition, currentPosition;

	// Use this for initialization
	void Start () {
		startPosition = new Vector3 (-stepsize, 0f, -stepsize);
		currentPosition = startPosition;
		generateStart ();
		generateRows ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = camera.transform.position;
		newPosition.z += scrollspeed;
		camera.transform.position = newPosition;

		scrollspeed += 0.00005f;

		if (Vector3.Distance (camera.transform.position, currentPosition) < 30) {
			generateRows ();
		}
	}

	void generateStart() {
		for (int i = 0; i < 2; ++i) {
			for (int j = 0; j < 3; ++j) {
				Instantiate (cube, currentPosition + new Vector3 (j * stepsize, 0, 0), new Quaternion ());
			}
			currentPosition += new Vector3 (0,0,stepsize);
		}
	}

	void generateRows() {
		for (int i = 0; i < 3; ++i) {
			bool obstacleGenerated = false;
			for (int j = 0; j < 3; ++j) {
				float rng = Random.Range (1, 101);
				if (rng <= 35 && !obstacleGenerated) {
					obstacleGenerated = true;
					int obs = Random.Range (0, 2);
					if (obs == 1) {
						Instantiate(obstacle, currentPosition + new Vector3 (j * stepsize, 1, 0), new Quaternion ());
						Instantiate (cube, currentPosition + new Vector3 (j * stepsize, 0, 0), new Quaternion ());
					}
				} else {
					Instantiate (cube, currentPosition + new Vector3 (j * stepsize, 0, 0), new Quaternion ());
				}
			}
			currentPosition += new Vector3 (0,0,stepsize);
		}
	}
}
