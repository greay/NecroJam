using UnityEngine;
using System.Collections;

public class SpellElement : MonoBehaviour {
	
	private SpellcastV1 spellManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetManager (SpellcastV1 mgr) {
		spellManager = mgr;
	}
	
	void OnMouseDown () {
		Debug.Log ("OnMouseDown(): " + name);
	}
}