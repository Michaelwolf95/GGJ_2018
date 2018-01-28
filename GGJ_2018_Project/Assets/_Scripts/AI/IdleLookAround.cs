using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleLookAround : MonoBehaviour
{
    public float changeDirectionTimer = 5f;
    public float rotationSpeed = 2f;
    public float maxRotation = 45f;

    private Quaternion start;

    private float direction;
    private float last = 0;

    // Use this for initialization
    void Start() {
        int[] randDirection = {-1, 1};
        direction = randDirection[Random.Range(0, randDirection.Length)];

        start = transform.rotation;
        Debug.Log("Transform:" + start.z);
        InvokeRepeating("LookAround", changeDirectionTimer, changeDirectionTimer);
	}
	
	// Update is called once per frame
    void LookAround()
    {
        direction *= -1;

        transform.rotation = Quaternion.Lerp(start, Quaternion.Euler(start.x, start.y, start.z + maxRotation * direction), Time.deltaTime * rotationSpeed);
    }
}
