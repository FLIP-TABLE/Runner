using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public PlayerManager playerManager;
    public GameObject killZone;
    public GameObject killZoneLeft;
    public Camera camera;
    
    private bool gameHasFinished;

    private float scrollspeed = 0.03f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // If not finished
        Vector3 newPosition = camera.transform.position;
        newPosition.x += scrollspeed;
        camera.transform.position = newPosition;

        newPosition = killZoneLeft.transform.position;
        newPosition.x += scrollspeed;
        killZoneLeft.transform.position = newPosition;

        scrollspeed += 0.00005f;
	}
}
