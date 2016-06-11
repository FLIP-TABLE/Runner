using UnityEngine;

public class Runner : MonoBehaviour {

    public Rigidbody rigidBody;
    public GameObject goal;

	void Update () {

        float speed = 5f;
        float jumpVelocity = 20f;

        if (Input.GetKey("left")) {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        } else if (Input.GetKey("right")) {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        if(Input.GetKey("up")){
            rigidBody.AddForce(new Vector3(0, jumpVelocity, 0));
		}

        if(this.transform.position.x > goal.transform.position.x) {
            print("You win!");
        }
	}
}