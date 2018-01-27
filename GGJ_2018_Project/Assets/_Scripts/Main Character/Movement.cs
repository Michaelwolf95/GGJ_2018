using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody2D rigidbody;
	public FDAnimation anim;
	float x, y;
	public float maxVelocity = 3;
	Vector2 movement;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.gravityScale = 0;
		//rigidbody.drag = force;

		movement = new Vector2(0, 0);
	}

	// Update is called once per frame
	void Update() {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		movement.Set(x, y);
		movement = movement.normalized;
	}

	void FixedUpdate() {
		/*if (movement.magnitude == 0) {
			rigidbody.drag = force;
		} else {
			rigidbody.drag = 0;
		}*/

		//rigidbody.AddForce(movement * force);
		//rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxVelocity);

		anim.SetAnimationDirection(movement);
		anim.SetAnimationSpeed(Mathf.Abs(movement.magnitude));

		rigidbody.MovePosition(rigidbody.position + movement * maxVelocity * Time.fixedDeltaTime);
	}

	public Vector2 getMove() {
		return movement;
	}
}
