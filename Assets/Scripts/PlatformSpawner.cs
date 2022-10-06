using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;
    public Transform lastPlatform;
    Vector3 lastPlatformPosition;
    Vector3 newPosition;

    bool stop = false;
    // Start is called before the first frame update
    void Start() {
        lastPlatformPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update() {
    }

    IEnumerator SpawnPlatforms() {

        while (!stop) {
            GeneratePosition();
            GameObject newPlatform = Instantiate(platformPrefab, newPosition, Quaternion.identity);
            lastPlatform = newPlatform.transform;
            lastPlatformPosition = lastPlatform.position;
            yield return new WaitForSeconds(0.4f);
        }
    }

    void GeneratePosition() {
        newPosition = lastPlatformPosition;
        int random = Random.Range(0, 2);
        if(random == 0) {
            newPosition.x += 2f;
        }
        else {
            newPosition.z += 2f;
        }
    }
}
