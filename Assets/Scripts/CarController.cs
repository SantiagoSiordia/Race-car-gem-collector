using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    bool isMovingLeft = true;
    bool firstInput = true;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.isGameStarted) {
            Move();
            CheckInput();
        }
    }

    void Move() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void CheckInput() {
        if(firstInput) {
            firstInput = false;
            return;
        }
        if (Input.GetMouseButtonDown(0)) ChangeDirection();
    }

    void ChangeDirection() {
        if(isMovingLeft) {
            transform.Rotate(0, 90, 0);
            isMovingLeft = false;
        }
        else {
            transform.Rotate(0, -90, 0);
            isMovingLeft = true;
        }
    }
}
