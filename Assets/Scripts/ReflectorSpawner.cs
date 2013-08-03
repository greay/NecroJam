using UnityEngine;
using System.Collections;

public class ReflectorSpawner : MonoBehaviour {
	
	public GameObject prefabToSpawn;
	void Awake () 
	{
		GameObject newObj = Instantiate(prefabToSpawn, transform.position, transform.rotation) as GameObject;
		Destroy(gameObject);
	}
}
