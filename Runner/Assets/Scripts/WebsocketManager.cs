using UnityEngine;
using System.Collections;
using System;

public class WebsocketManager : MonoBehaviour
{
    public PlayerManager playerManager;

    // Use this for initialization
    IEnumerator Start()
    {
        string uri = "ws://178.62.226.87:8000/";

        WebSocket w = new WebSocket(new Uri(uri));
        yield return StartCoroutine(w.Connect());
        print("Started websocket server at: " + uri);

        while (true)
        {
            string reply = w.RecvString();
            if (reply != null)
            {
                if (isValidMessage(reply)) {

                    string id = parsePlayerId(reply);
                    
                    if (!playerManager.hasPlayer(id)) {
                        playerManager.createPlayer(id);
                    }

                    Runner currentRunner = playerManager.getPlayer(id);

                    if (reply.Contains("rotation")) {
                        float speed = parseSpeed(reply);
                        print("Speed: " + speed);
                        currentRunner.setLastSpeed(speed);
                    } else if (reply.Contains("jump")) {
                        currentRunner.setShouldJump();
                    }
                }
            }
            if (w.Error != null)
            {
                Debug.LogError("Error: " + w.Error);
                break;
            }
            yield return 0;
        }
        w.Close();
    }

    public void FixedUpdate() {
    }

    public float parseSpeed(string json) {

        string[] jsonSplit = json.Split(null);
        float speed = float.Parse(jsonSplit[jsonSplit.Length - 1]);

        float maxSpeed = 5;

        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        speed = speed * 0.25f;

        return speed;
    }

    private bool isValidMessage(string json) {
        if (json.Contains("connected") || json.Contains("Hello") || json.Contains("Error") || json.Contains("null"))
        {
            return false;
        }

        return true;
    }

    private string parsePlayerId(string json) {
        string[] jsonSplit = json.Split(null);
        string id = jsonSplit[0];

        return id;
    }
}