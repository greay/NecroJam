using UnityEngine;
using System.Collections;

public class SpellElement : MonoBehaviour {
	
	private SpellcastV1 spellManager;
	private Vector3 startPoint;
	private Vector3 endPoint;
	private bool moving = false;
	
	private Vector3 lastMouseScreenPosition;
	
	public float positionPercentage = 0.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		audio.pitch = Mathf.Lerp (0.1f, 3f, positionPercentage);
		
		if (moving) {
			if (Input.GetMouseButton(0) == false) {
				moving = false;
			}
			
			if (moving) {
				Vector3 mouseDelta = Input.mousePosition - lastMouseScreenPosition;
//				Vector3 mouseDirection = mouseDelta.normalized;
//				float mouseMagnitude = mouseDelta.magnitude;
				
				float appliedValue = 0f;
				if (Mathf.Abs (mouseDelta.x) > Mathf.Abs (mouseDelta.y)) {
					appliedValue += mouseDelta.x;
				}
				else {
					appliedValue += mouseDelta.y;
				}
				
				positionPercentage += appliedValue * 0.02f;
				positionPercentage = Mathf.Clamp (positionPercentage, 0, 1);
				lastMouseScreenPosition = Input.mousePosition;
			}
		}
	}
	
	public void SetManager (SpellcastV1 mgr) {
		spellManager = mgr;
	}
	
	public void SetStartEndPoints (Vector3 start, Vector3 end) {
		startPoint = start;
		endPoint = end;
	}
	
	void OnMouseDown () {
//		Debug.Log ("OnMouseDown(): " + name);
		moving = true;
		lastMouseScreenPosition = Input.mousePosition;
	}
}