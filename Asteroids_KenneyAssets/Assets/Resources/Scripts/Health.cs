using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    int health;
    public void SetHealth(int health) { this.health = health; }
    public int GetHealth() { return health; }

    private void Awake() {
       
    }
    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            health = 0;
        }
        IHitable hitable = GetComponent<IHitable>();
        if(hitable != null) {
            GetComponent<IHitable>().OnHit();
        }
    }
    public void Heal(int points) {
        health += points;
    }

    private void Update() {
        if(health <= 0) {
            IDestructable destructable = GetComponent<IDestructable>();
            if (destructable != null)
                GetComponent<IDestructable>().OnDestruction();
        }
    }
}
