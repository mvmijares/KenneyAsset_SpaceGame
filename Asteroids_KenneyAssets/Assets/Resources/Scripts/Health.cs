using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    int health;
    public void SetHealth(int health) { this.health = health; }
    public int GetHealth() { return health; }
    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            health = 0;
        }
    }
    public void Heal(int points) {
        health += points;
    }

    private void Update() {
        if(health <= 0) {
            Destroy(this.gameObject);
        }
    }
}
