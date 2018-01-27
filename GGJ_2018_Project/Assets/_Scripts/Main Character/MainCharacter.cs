using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(FDAnimation))]

public class MainCharacter : MonoBehaviour {

	FDAnimation fd;
	Movement move;
	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		fd = GetComponent<FDAnimation>();
		move = GetComponent<Movement>();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		fd.SetAnimationDirection(move.getMove());
		fd.SetAnimationSpeed(Mathf.Abs(rigidbody.velocity.magnitude));
	}
}
