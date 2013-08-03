using UnityEngine;
using System.Collections;

public class ReflectorInstigatorHandler : MonoBehaviour {
	
	public float randomScaleAmount;
	public Vector2 randomForceAmount;
	public Vector3 randomInertiaTensorAmount;
	public float randomSpinAmount;
	
	private float randomScale;
	private Vector2 randomForce;
	private Vector3 randomIntertiaTensor;
	private float randomSpin;
	
	private Transform cachedTransform;
	private Rigidbody cachedRigidbody;
	
	// Use this for initialization
	void Start () 
	{
		randomScale = Random.Range(.25F,randomScaleAmount);
		randomForce.x = Random.Range(0F, randomForceAmount.x);
		randomForce.y = Random.Range(0F, randomForceAmount.y);
		
		randomIntertiaTensor.x = Random.Range(0F, randomInertiaTensorAmount.x);
		randomIntertiaTensor.y = Random.Range(0F, randomInertiaTensorAmount.y);
		randomIntertiaTensor.z = Random.Range(0F, randomInertiaTensorAmount.z);
		
		randomSpin = Random.Range(0F, randomSpinAmount);
		
		cachedTransform = gameObject.transform;
		cachedRigidbody = gameObject.rigidbody;
		
		cachedTransform.localScale = new Vector3 (randomScale, randomScale, randomScale);
		cachedRigidbody.AddForce(randomForce.x, randomForce.y,0);
		cachedRigidbody.inertiaTensor = new Vector3(
			randomIntertiaTensor.x, randomIntertiaTensor.y, randomIntertiaTensor.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (randomSpinAmount != 0 && randomSpin != 0)
		{
			cachedTransform.Rotate(0,randomSpin,0);
		}
	}
}
