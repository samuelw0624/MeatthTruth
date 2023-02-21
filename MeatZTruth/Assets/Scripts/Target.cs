using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRb;
    ClickerManager cManagerScript;
    public ParticleSystem explosionParticle;

    float minForce = 13.0f;
    float maxForce = 17.0f;
    float maxTorque = 10.0f;
    float xSpawnRange = 4.0f;
    float ySpawnPos = -3.0f;

    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        cManagerScript = GameObject.Find("Clicker Manager").GetComponent<ClickerManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(TorqueRange(), TorqueRange(), TorqueRange(), ForceMode.Impulse);

        transform.position = SpawnPos();
    }

    private void OnMouseDown()
    {
        if (cManagerScript.isGameAvtive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            cManagerScript.ScoreCount(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            cManagerScript.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    float TorqueRange()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos, 0);
    }
}
