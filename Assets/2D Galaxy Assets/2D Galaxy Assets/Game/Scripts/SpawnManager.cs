using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField] private GameObject EnemyPrefab = null;
    [SerializeField] private GameObject[] PowerupPrefabs = null;
        // [] means an array

    // Start is called before the first frame update
    void Start() {
        
        StartCoroutine(EnemySpawnRoutine());

        StartCoroutine(PowerupSpawnRoutine());
    }

    // Update is called once per frame
    void Update() {
        
    }

    private IEnumerator EnemySpawnRoutine() {

        while (true) {

            Instantiate(EnemyPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 6.5f, 0f), Quaternion.identity);
            Instantiate(EnemyPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 6.5f, 0f), Quaternion.identity);

            yield return new WaitForSeconds(3.0f);
        }
    }

    private IEnumerator PowerupSpawnRoutine() {

        while (true) {

            int r = Random.Range(0,4);

            Instantiate(PowerupPrefabs[r], new Vector3(Random.Range(-7.5f, 7.5f), 6.5f, 0f), Quaternion.identity);

            yield return new WaitForSeconds(10.0f);
        }
    }

}
