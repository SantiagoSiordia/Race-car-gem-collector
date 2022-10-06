using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    public float smoothSpeed;
    // Start is called before the first frame update
    void Start() {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update() {
        Follow();
    }

    void Follow() {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = target.position - offset;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
