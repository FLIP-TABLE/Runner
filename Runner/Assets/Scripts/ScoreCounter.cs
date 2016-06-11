using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public FloorGenerator floorGenerator;
    public Text text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "" + floorGenerator.numHolesReached();
	}
}
