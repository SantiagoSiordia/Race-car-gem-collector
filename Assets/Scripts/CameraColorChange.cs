using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChange : MonoBehaviour
{

    public Color[] colors;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine("ChangeColor");
    }

    // Update is called once per frame
    void Update() {
    }

    IEnumerator ChangeColor() {
        while (true) {
            Camera.main.backgroundColor = colors[Random.Range(0, colors.Length)];
            yield return new WaitForSeconds(5);
        }
    }
}
