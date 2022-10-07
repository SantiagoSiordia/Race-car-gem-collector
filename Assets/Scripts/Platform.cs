using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject diamondPrefab;

    // Start is called before the first frame update
    void Start() {
        SpawnDiamond();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            Invoke("Fall", 0.2f);
        }
    }

    void Fall() {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }

    void SpawnDiamond () {
        int randomDiamond = Random.Range(0, 5);

        Vector3 diamondPos = transform.position;
        diamondPos.y += 1;

        if(randomDiamond == 0) {
            Instantiate(diamondPrefab, diamondPos, diamondPrefab.transform.rotation);
        }
    }
}
