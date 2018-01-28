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

			float[] distance = new float[4];
			int leastIndex = 0;
			float leastValue = Mathf.Infinity;

			distance[0] = Vector2.Distance(save, Vector2.left);
			distance[1] = Vector2.Distance(save, Vector2.right);
			distance[2] = Vector2.Distance(save, Vector2.up);
			distance[3] = Vector2.Distance(save, Vector2.down);

			for(int i = 0; i < distance.Length; i++) {
				if(distance[i] < leastValue) {
					leastIndex = i;
					leastValue = distance[i];
				} 
			}

			switch(leastIndex) {
				case 0: moveDirection.Set(-.1f, 0); break;
				case 1: moveDirection.Set(.1f, 0); break;
				case 2: moveDirection.Set(0, -.1f); break;
				case 3: moveDirection.Set(0, .1f); break;
			}
			
			if(!useDownward && leastIndex == 2) {
				if(save.x >= 0) {
					moveDirection.Set(.1f, 0);
				}
			}
						
		} else {

			save = moveDirection;

			if (save != null) {
				if (!useDownward) {
					if (moveDirection.y < 0 && positive) {
						moveDirection.Set(1, 0);
					} else if (moveDirection.y < 0) {
						moveDirection.Set(-1, 0);
					}
				}
			}

			if (save.x > 0) {
				positive = true;
			} else if(save.x < 0) {
				positive = false;
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
