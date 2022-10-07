using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    bool isMovingLeft = true;
    bool firstInput = true;
    public GameObject particleEffect;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.isGameStarted) {
            Move();
            CheckInput();
        }

        if(transform.position.y < -2) {
            GameManager.instance.GameOver();
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

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Diamond") {
            other.gameObject.SetActive(false);

            Instantiate(particleEffect, other.transform.position, Quaternion.identity);
            GameManager.instance.IncrementScore();
            AudioManager.instance.PlayDiamondSound();
        }
    }
}
