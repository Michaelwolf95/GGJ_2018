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

    void Update()
    {
        if (_sr)
        {
            //float ypos = _sr.bounds.
            if (this.transform.position.y <= -100f)
            {
                _sr.sortingOrder = -200;
            }
            else if (this.transform.position.y >= 100f)
            {
                _sr.sortingOrder = 200;
            }
            else
            {
                float yPos = this.transform.position.y + 100f;
                _sr.sortingOrder = -(int)(yPos * 2f);
            }
            //_sr.sortingOrder
        }
    }
}
