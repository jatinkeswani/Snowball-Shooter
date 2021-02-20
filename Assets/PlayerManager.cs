using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    
    [HideInInspector] public bool gameStarted = false;
    public GameObject playerHolder;
    public GameObject iceBallPrefab;
    public GameObject snowParticle;
    GameObject iceBall;
    [HideInInspector] public bool isball = false; 
    Vector3 spawnPos = new Vector3(0f, 0.25f, 0.75f);

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isball)
        {
            isball = false;
            ShootIceBall();
        }
    }

    void ShootIceBall()
    {
        iceBall.GetComponent<SphereCollider>().enabled = true;
        iceBall.transform.parent = null;
        iceBall.GetComponent<BallShoot>().enabled = true;
        iceBall = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            
            if (!isball)
            {
                Destroy(other.gameObject);
                Instantiate(snowParticle, other.transform.position, Quaternion.identity);
                Instantiate(GameManager.instance.snowSoundPrefab, other.transform.position, Quaternion.identity);
                iceBall = Instantiate(iceBallPrefab, playerHolder.transform.position + spawnPos, Quaternion.identity, playerHolder.transform);
                isball = true;
            }
            else
            {
                if (iceBall.transform.localScale.x < 5f && iceBall != null)
                {
                    Destroy(other.gameObject);
                    Instantiate(snowParticle, other.transform.position, Quaternion.identity);
                    Instantiate(GameManager.instance.snowSoundPrefab, other.transform.position, Quaternion.identity);
                    iceBall.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                    iceBall.transform.localPosition += new Vector3(0f, 0.05f, 0.05f);
                }
            }
        }

        if (other.CompareTag("Block"))
        {
            gameStarted = false;
            GetComponent<Animator>().SetTrigger("die");
            GameManager.instance.Invoke("ShowRetryButton", 1.0f);
            
        }

        if (other.CompareTag("Ending"))
        {
            gameStarted = false;
            GameManager.instance.ShowNextButton();
        }
    }
}
