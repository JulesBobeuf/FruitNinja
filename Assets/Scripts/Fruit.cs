using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	public GameObject slicedFruitPrefab;

	public int nbPoints;

	public void CreateSliceFruit()
	{
		GameObject instance = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

		Rigidbody[] rbsOnSlice = instance.transform.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rbs in rbsOnSlice)
		{
			rbs.transform.rotation = Random.rotation;
			rbs.AddExplosionForce(Random.Range(500,1000),transform.position,5);
		}
        GameManager g = FindObjectOfType<GameManager>();
		g.IncreaseScore(nbPoints);
        Destroy(instance.gameObject, 5);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		Blade b = coll.GetComponent<Blade>();

		if (!b)
		{
			return;
		}
		CreateSliceFruit();
		
	}
}
