using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDepth : MonoBehaviour
{
    private SpriteRenderer _sr;

    void Awake()
    {
        _sr = GetComponentInParent<SpriteRenderer>();
    }

    //void OnTriggerStay2d(Collider2D c) {
    //    if (_sr) {
    //        _sr.sortingOrder = (int)c.transform.position.y * 2;
    //        if (c.transform.position.y > GetComponentInParent<Transform>().position.y) {
    //            _sr.sortingOrder = _sr.sortingOrder - 1;
    //        }
    //        else {
    //            _sr.sortingOrder = _sr.sortingOrder + 1;
    //        }
    //    }
    //}

    void Update() {
        //Debug.DrawLine(this.transform.position, _sr.bounds.min, Color.red);
        if (_sr) {
            float yPos = _sr.bounds.min.y;
            if (yPos <= -100f) {
                _sr.sortingOrder = -200;
            }
            else if (yPos >= 100f) {
                _sr.sortingOrder = 200;
            }
            else {
                yPos = yPos + 100f;
                _sr.sortingOrder = -(int)(yPos * 2f);
            }
            //_sr.sortingOrder
        }
    }
}
