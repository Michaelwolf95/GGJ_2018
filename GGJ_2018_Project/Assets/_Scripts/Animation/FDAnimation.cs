using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class FDAnimation : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.runtimeAnimatorController = Instantiate(Resources.Load("FDAnimationController")) as RuntimeAnimatorController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAnimationDirection(Vector2 moveDirection) {
		anim.SetFloat("x", moveDirection.x);
		anim.SetFloat("y", moveDirection.y);
	}
}
