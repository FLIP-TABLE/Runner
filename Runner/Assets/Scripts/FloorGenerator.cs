using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorGenerator : MonoBehaviour {

	enum TILE{Floor, Hole, Step, Stair};

    private int numHoles = 10;

	public GameObject cubePrefab;
    public GameObject runner;
    public List<Vector3> holePositions;

	private int holesGenerated = 0;
    private Vector3 startPosition;
	private Vector3 currentPosition;
	private float stepSize = 1.0f;
    private Vector3 floorOffset = new Vector3(-2, -3, 0);

	// Use this for initialization
	void Start () {
        holePositions = new List<Vector3>();

        startPosition = runner.transform.position + floorOffset;
        currentPosition = startPosition;
        generatePlatform();
	}
	
	// Update is called once per frame
	void Update () {
        if (reachedEnd()) {
            print("You won!");
        }
	}

	void generatePlatform() {
		generateStart ();
		while (holesGenerated < numHoles) {
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
		currentPosition.x += stepSize * 1.2f;
		holesGenerated++;
		generateFloor ();

        holePositions.Add(currentPosition);
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

    bool reachedEnd() {
        return (runner.transform.position.x > holePositions[holePositions.Count - 1].x);
    }

    public int numHolesReached() {

        int count = 0;

        for (int i = 0; i < holePositions.Count; i++) {
            if (runner.transform.position.x > holePositions[i].x) {
                count++;
            }
        }

        return count;
    }
}
