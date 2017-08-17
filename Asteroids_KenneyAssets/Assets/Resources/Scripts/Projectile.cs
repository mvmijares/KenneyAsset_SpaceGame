using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Rigidbody2D rb;
    float speed;
    int damageValue;
    public void SetDamageValue(int value) {
        damageValue = value;
    }
    public int GetDamageValue() { return damageValue; }
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        speed = 40.0f; // we'll set this up in the player class
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        Vector3 force = transform.right * speed;
        rb.velocity = force; // constant velocity
    }
}
