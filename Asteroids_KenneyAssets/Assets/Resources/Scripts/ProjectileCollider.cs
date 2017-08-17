using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour {

    Projectile projectile;
    Transform parent;
    private void Awake() {
        projectile = GetComponentInParent<Projectile>();
        parent = transform.parent;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Transform gameObj = collision.transform;
        if (gameObj.GetComponent<Asteroid>()) {
            gameObj.GetComponent<Health>().TakeDamage(projectile.GetDamageValue());
            Destroy(this.gameObject);
        }
    }
}
