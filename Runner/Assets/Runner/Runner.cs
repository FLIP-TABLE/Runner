using UnityEngine;

public class Runner : MonoBehaviour {

    private string id;

    private Rigidbody rigidBody;
    private Vector3 startPosition;
    private bool touchingPlatform;
    private bool runnerHasFinished;

    private float maxSpeed = 5f;
    private float jumpVelocity = 10f;
    private float lastSpeed = 0f;
    private bool shouldJump = false;
    private bool hasDied = false;

    void Start () {
        startPosition = this.transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

	void Update () {

        if (Input.GetKey("left")) {
            lastSpeed = -1;
        } else if (Input.GetKey("right")) {
            lastSpeed = 1;
        }

        move(lastSpeed * maxSpeed * Time.deltaTime);

        if(touchingPlatform && (Input.GetKey("up") || shouldJump)){
            shouldJump = false;
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpVelocity, rigidBody.velocity.z);
		}

        if(hasFinished()) {
            print("You win!");
        }
	}

    public void move(float speed) {
        transform.Translate(speed, 0f, 0f);
    }

    bool hasFinished() {
        if (runnerHasFinished) {
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

    public void setLastSpeed (float currentSpeed) {
        lastSpeed = currentSpeed;
    }

    public void setShouldJump() {
        if (touchingPlatform) {
            shouldJump = true;
        }
    }

    public string getId() {
        return id;
    }

    public void setId(string id) {
        this.id = id;
    }

    public void setHasDied(bool hasDied) {
        this.hasDied = hasDied;
    }

    public bool getHasDied() {
        return hasDied;
    }
}