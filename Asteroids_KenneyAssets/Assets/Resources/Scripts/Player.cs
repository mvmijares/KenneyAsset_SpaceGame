using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;

    float horizontal;
    float vertical;

    float speed;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        speed = 10f;
    }
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Debug.Log("Vertical " + vertical + " " + "Horizontal" + horizontal);
	}
    //Physics
    private void FixedUpdate() {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);

        rb.MovePosition(playerPos + new Vector2(horizontal, vertical) * Time.deltaTime * speed);
        
    }

    //used for follow camera
    private void LateUpdate() {
        
    }
}
