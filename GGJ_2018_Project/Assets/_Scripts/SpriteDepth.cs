using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDepth : MonoBehaviour {
    private SpriteRenderer _sr;
    void Awake() {
        _sr = GetComponentInParent<SpriteRenderer>();
    }
	// Update is called once per frame
	void OnTriggerStay2D(Collider2D c) {
        _sr.sortingOrder = (int)c.transform.position.y * 2;
        if (c.transform.position.y > GetComponentInParent<Transform>().position.y) {          
            c.GetComponent<SpriteRenderer>().sortingOrder = _sr.sortingOrder - 1;
        }
        else {
            c.GetComponent<SpriteRenderer>().sortingOrder = _sr.sortingOrder + 1;
        }
    }
}
