using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class FDAnimation : MonoBehaviour {
	Animator anim;
	Vector2 save = new Vector2(.1f, 0);

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
		} else {
			save = moveDirection;
		}

		anim.SetFloat("x", moveDirection.x);
		anim.SetFloat("y", moveDirection.y);
	}
}
