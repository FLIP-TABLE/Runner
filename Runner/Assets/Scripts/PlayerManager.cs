using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public GameObject playerPrefab;
    private Dictionary<string, Runner> playerMap;

	// Use this for initialization
	void Start () {
        playerMap = new Dictionary<string, Runner>();
	}

    public bool hasPlayer(string id) {
        return playerMap.ContainsKey(id);
    }

    public void createPlayer(string id) {
        GameObject go = (GameObject)Instantiate(playerPrefab);
        Runner runner = go.GetComponent<Runner>();
        runner.setId(id);

        playerMap.Add(id, runner);
    }

    public Runner getPlayer(string id) {
        return playerMap[id];
    }

    public Dictionary<string, Runner> getPlayerMap() {
        return playerMap;
    }
}
