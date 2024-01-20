using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] objectsToSpawn;
	public Transform[] spawnPlaces;
	public float minWait = .3f;
	public float maxWait = 1f;
	public float minForce = 12.5f;
	public float mawForce = 18f;

    // Use this for initialization
    void Start () {
		StartCoroutine(SpawnFruits());
	}

	private IEnumerator SpawnFruits()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWait, maxWait));

			Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject objToSpawn = null;
            float p = Random.Range(0,100);
			if (p<10)
			{
				objToSpawn = objectsToSpawn[0];
            }
			else if (p<20)
			{
				objToSpawn = objectsToSpawn[1];
			}
			else
			{
                objToSpawn = objectsToSpawn[Random.Range(2, objectsToSpawn.Length)];
            }


			GameObject fruit = Instantiate(objToSpawn, t.position, t.rotation);

			fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,mawForce), ForceMode2D.Impulse);

			Destroy(fruit, 5);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
