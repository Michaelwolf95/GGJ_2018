using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class FDAnimation : MonoBehaviour {
	Animator anim;
	Vector2 save = new Vector2(.1f, 0);
	public bool useDownward = false;
	bool positive = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	public void SetAnimationDirection(Vector2 moveDirection) {
		if(moveDirection.magnitude == 0) {
			if(!positive) {
				moveDirection.Set(-.1f, 0);
			} else {
				moveDirection.Set(.1f, 0);
			}
						
		} else {

			save = moveDirection;

			if (save.x > 0) {
				positive = true;
			} else if(save.x < 0) {
				positive = false;
			}

			if(positive) {
				moveDirection.Set(1, 0);
			} else {
				moveDirection.Set(-1, 0);
			}
		}

		anim.SetFloat("x", moveDirection.x);
		anim.SetFloat("y", moveDirection.y);
	}

	public void setDownward(bool tf) {
		useDownward = tf;
	}

	public bool getDownward() {
		return useDownward;
	}
}
