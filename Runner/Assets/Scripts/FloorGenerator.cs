using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

	enum TILE{Floor, Hole, Step, Stair};

	public GameObject cubePrefab;

	private int holesGenerated = 0;
	private Vector3 startPosition = new Vector3 (-30, -10, 0);
	private Vector3 currentPosition;
	private float stepSize = 1.0f;

	// Use this for initialization
	void Start () {
		currentPosition = startPosition;
		generatePlatform ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void generatePlatform() {
		generateStart ();
		while (holesGenerated < 10) {
			TILE type = getRandomEnum<TILE> ();
			switch(type) {
			case TILE.Hole:
				generateHole ();
				break;
			case TILE.Step:
				generateStep ();
				break;
			case TILE.Stair:
				break;
			default:
				generateFloor ();	
				break;
			}
		}
		generateEnd ();
	}

	void generateEnd() {
		for (int i = 0; i < 4; ++i) {
			generateFloor ();
		}
	}

	void generateStart() {
		for (int i = 0; i < 4; ++i) {
			generateFloor ();
		}
	}

	void generateHole() {
		currentPosition.x += stepSize;
		holesGenerated++;
		generateFloor ();
	}

	void generateStep() {
		generateFloor ();
		Instantiate (cubePrefab, currentPosition + new Vector3(0f, stepSize, 0f), new Quaternion ());
	}

	void generateStair() {
		// TODO
	}

	void generateFloor () {
		currentPosition.x += stepSize;
		Instantiate (cubePrefab, currentPosition, new Quaternion ());
	}

	T getRandomEnum<T>() {
		System.Array A = System.Enum.GetValues (typeof(TILE));
		T V = (T)A.GetValue(Random.Range(0,A.Length));
		return V;
	}
}
