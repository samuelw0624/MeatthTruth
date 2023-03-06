using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    ClickerManager cManagerScript;
    Rigidbody targetRb;
    public ParticleSystem explosionParticle;

    [SerializeField] float minForce = 13.0f;
    [SerializeField] float maxForce = 17.0f;
    [SerializeField] float maxTorque = 1.5f;
    [SerializeField] float xSpawnRange = 6.0f;
    [SerializeField] float ySpawnPos = -2.5f;

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
            Instantiate(explosionParticle, transform.position, transform.rotation);
            cManagerScript.ScoreCount(pointValue);
            if (gameObject.CompareTag("Bomb"))
            {
                cManagerScript.GameOver();
            }
            Destroy(gameObject);
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
