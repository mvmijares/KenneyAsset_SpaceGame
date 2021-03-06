﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDestructable, IHitable {

    Rigidbody2D rb;

    float horizontal;
    float vertical;

    float speed;
    Vector2 playerPos;

    public bool debugCondition;

    public GameObject projectile;
    public Transform bulletSpawnLocation;

    public int damage; // change this up when we have customizeable weapons
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        speed = 10f;
        debugCondition = false;
    }
    // Use this for initialization
    void Start () {

        Physics2D.IgnoreLayerCollision(8, 9); // Change for later
        Physics2D.IgnoreLayerCollision(8, 8);
	}
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        DebugFunction();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

        if (Input.GetKeyDown(KeyCode.Space)) {
            FireBullets();  
        }
    }
    //Physics
    private void FixedUpdate() {
        playerPos = new Vector2(transform.position.x, transform.position.y);
        rb.MovePosition(playerPos + new Vector2(horizontal, vertical) * Time.deltaTime * speed);
    }
    void FireBullets() {
        Vector3 relativePos = bulletSpawnLocation.position + transform.position; // bulletspawnPosition relative to parent;
        GameObject clone = Instantiate(projectile, relativePos, transform.rotation);
        clone.GetComponent<Projectile>().SetDamageValue(damage);
        DestroyObject(clone, 5.0f); // change this up when we have customizeable weapons
    }
    //used for follow camera
    private void LateUpdate() {
        
    }

    public void OnHit() {

    }
    public void OnDestruction() {

    }
    void DebugFunction() {
        if (debugCondition)
            Debug.Log("Vertical " + vertical + " " + "Horizontal" + horizontal);
        else {
            Debug.ClearDeveloperConsole();
        }
    }
}
