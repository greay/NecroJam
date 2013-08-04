using UnityEngine;
using System.Collections;

public class ReflectorInstigatorHandler : MonoBehaviour {
	
	public Animation emitAnimationRef;
	
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
	private bool spinActive=false;
	
	// Use this for initialization
	void Start () 
	{
		RandomizeValues();
		cachedTransform = gameObject.transform;
		cachedRigidbody = gameObject.rigidbody;
	}
	
	void RandomizeValues()
	{
		randomScale = Random.Range(.25F,randomScaleAmount);
		
		randomForce.x = Random.Range(0F, randomForceAmount.x);
		randomForce.y = Random.Range(0F, randomForceAmount.y);
		
		randomIntertiaTensor.x = Random.Range(0F, randomInertiaTensorAmount.x);
		randomIntertiaTensor.y = Random.Range(0F, randomInertiaTensorAmount.y);
		randomIntertiaTensor.z = Random.Range(0F, randomInertiaTensorAmount.z);
		
		randomSpin = Random.Range(0F, randomSpinAmount);
	}
	
	void Update () 
	{
		if (randomSpinAmount != 0 && randomSpin != 0 && spinActive)
		{
			cachedTransform.Rotate(0,randomSpin,0);
		}
	}
	
	public void ActivateInstigator()
	{
		spinActive=true;
		cachedTransform.localScale = new Vector3 (randomScale, randomScale, randomScale);
		cachedRigidbody.AddForce(randomForce.x, randomForce.y,0);
		cachedRigidbody.inertiaTensor = new Vector3(
			randomIntertiaTensor.x, randomIntertiaTensor.y, randomIntertiaTensor.z);
		emitAnimationRef.Play();
	}
	
	void OnGUI()
	{	
        if (GUI.Button(new Rect(10, 70, 50, 30), "GO"))     
			ActivateInstigator();
	}
}