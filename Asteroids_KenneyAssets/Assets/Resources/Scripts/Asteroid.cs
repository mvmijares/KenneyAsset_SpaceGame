using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDestructable, IHitable {

    public GameObject particleSystem;

    GameObject onHitEffect;
    ParticleSystem onHitEffectComponent;

    Mesh testMesh;
    int numOfVertices;
    float radius;
    public float objectScale;
    public void SetObjectScale(float scale) {
        objectScale = scale;
    }
    private void Awake() {
        radius = 1f * objectScale;
    }
    void Start () {
        transform.localScale = new Vector2(transform.localScale.x * objectScale, transform.localScale.y * objectScale);

        onHitEffect = Instantiate(particleSystem, transform.position, transform.rotation) as GameObject;
        onHitEffect.transform.SetParent(this.transform, false);
        onHitEffectComponent = onHitEffect.GetComponent<ParticleSystem>();

        ParticleSystem.ShapeModule sh = onHitEffectComponent.GetComponent<ParticleSystem>().shape;
        sh.enabled = true;
        sh.shapeType = ParticleSystemShapeType.Mesh;
        numOfVertices = 20;
        sh.mesh = CreateCircleParticleSystemMesh(transform.position, radius, numOfVertices);
        sh.sphericalDirectionAmount = 1.0f;

        testMesh = CreateCircleParticleSystemMesh(transform.position, radius, numOfVertices);
        onHitEffectComponent.Play();
    }
    /// <summary>
    /// Function to create mesh for particle system to emit particles around edge of a circle 
    /// </summary>
    /// <param name="pos">position of circle</param>
    /// <param name="r">radius of circle</param>
    /// <param name="numVertices">number of vertices for the circle to have</param>
    Mesh CreateCircleParticleSystemMesh(Vector2 pos, float r, int numVertices) {
        Mesh newMesh = new Mesh();
        Vector3[] vertices = new Vector3[numVertices];
        float x = 0;
        float y = 0;
        float angleIncrement = 2 * Mathf.PI / numVertices;
        float theta = 0;
        int[] t = new int[numVertices * 3];
        for (int i = 0; i < numVertices; i++, theta += angleIncrement) {
            x = pos.x + r * Mathf.Cos(theta);
            y = pos.y - r * Mathf.Sin(theta);
            vertices[i] = new Vector2(x, y);
        }
        //triangles
        for(int i = 0; i  + 2 < numVertices; ++i) {
            int index = i * 3;
            t[index + 0] = 0;
            t[index + 1] = i + 1;
            t[index + 2] = i + 2;
        }
        int last = t.Length - 3;
        t[last + 0] = 0;
        t[last + 1] = numVertices - 1;
        t[last + 2] = 1;

        newMesh.vertices = vertices;
        newMesh.triangles = t;
        return newMesh;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void OnDestruction() {
        Destroy(this.gameObject);
    }
    public void OnHit() {
        onHitEffectComponent.Play();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if (testMesh) {
            for (int i = 0; i < testMesh.vertices.Length; i++) {
                Gizmos.DrawSphere(testMesh.vertices[i], 0.05f);
            }
        }
    }
}
