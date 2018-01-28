using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAnimHook : MonoBehaviour {

	NavMeshAgent2D navMesh;
	FDAnimation anim;

	// Use this for initialization
	void Start () {
		navMesh = GetComponentInParent<NavMeshAgent2D>();
		anim = GetComponent<FDAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetAnimationDirection(navMesh.velocity);
	}
}
