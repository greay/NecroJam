using UnityEngine;
using System.Collections;

public class ReflectorHandler : MonoBehaviour {
	
	
	public float reflectLength = .5F;
	public Animation emitAnimationRef;
	
	private bool hasReflected = false;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "reflector" && !hasReflected)
		{
			EmitReflection();
		}
	}
	
	void EmitReflection()
	{
		emitAnimationRef.Play();
	}
	
}
