using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public GameObject trailPrefab;
    GameObject trail;
    public GameObject destroyParticle;


    private void OnEnable()
    {
        trail = Instantiate(trailPrefab, new Vector3(transform.position.x, 0.001f, transform.position.z), Quaternion.EulerRotation(90f, 0f, 0f), this.gameObject.transform);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 15f);
        if (transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            // trail.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            trail.transform.position = new Vector3(transform.position.x, 0.001f, transform.position.z);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Invoke("DestroyThis", 0.1f);
        }
    }

    void DestroyThis()
    {
        trail.transform.parent = null;
        Destroy(this.gameObject);
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
    }
}
