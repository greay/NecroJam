using UnityEngine;
using System.Collections;

public class SpellcastV1 : MonoBehaviour {
	
	public SpellElement visualIndicator;
	public Transform startPoint;
	public Transform endPoint;
	
	public float positionPercentage = 0.5f;

	// Use this for initialization
	void Start () {
		startPoint.renderer.enabled = false;
		endPoint.renderer.enabled = false;
		visualIndicator.SetManager (this);
	}
	
	// Update is called once per frame
	void Update () {
		visualIndicator.transform.position = Vector3.Lerp (startPoint.position, endPoint.position, positionPercentage);
	}
}
