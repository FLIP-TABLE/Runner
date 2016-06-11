using UnityEngine;

public class Runner : MonoBehaviour {

    public Rigidbody rigidBody;
    public GameObject camera;
    public GameObject goal;
    public GameObject killZone;
    public GameObject killZoneLeft;

    private Vector3 startPosition;
    private bool touchingPlatform;
    private bool runnerHasFinished;
    private bool gameHasFinished;

    void Start () {
        startPosition = this.transform.position;
    }

	void Update () {

        float speed = 3f;
        float jumpVelocity = 5f;
        float scrollspeed = 0.03f;

        if (Input.GetKey("left")) {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        } else if (Input.GetKey("right")) {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        if(touchingPlatform && Input.GetKey("up")){
            //rigidBody.AddForce(new Vector3(0, jumpVelocity, 0));
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpVelocity, rigidBody.velocity.z);
		}

        if (!hasFinished() && !hasDied()) {
            Vector3 newPosition = camera.transform.position;
            newPosition.x += scrollspeed;
            camera.transform.position = newPosition;

            newPosition = killZoneLeft.transform.position;
            newPosition.x += scrollspeed;
            killZoneLeft.transform.position = newPosition;
        }

        if(hasFinished()) {
            print("You win!");
        }

        if (hasDied()) {
            print("You died!");
            //this.transform.position = startPosition;
            //rigidBody.velocity = Vector3.zero;
        }
	}

    bool hasFinished() {
        if (runnerHasFinished) {
            return true;
        }
//        else if (this.transform.position.x > goal.transform.position.x) {
//            runnerHasFinished = true;
//            return true;
//        }

        return false;
    }

    bool hasDied(){
        if(gameHasFinished) {
            return true;
        }
        else if (
          (this.transform.position.y < killZone.transform.position.y) ||
          (this.transform.position.x < killZoneLeft.transform.position.x)) {
              gameHasFinished = true;
              return true;
        }

        return false;
    }

    void OnCollisionEnter(Collision collision) {
        touchingPlatform = true;
    }

    void OnCollisionExit(Collision collision) {
        touchingPlatform = false;
    }
}