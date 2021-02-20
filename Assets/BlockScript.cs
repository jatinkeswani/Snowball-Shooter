using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public Material grey;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("IceBall"))
        {
            GetComponent<MeshRenderer>().material = grey;
            Invoke("ChangeTag", 0.1f);
        }
    }

    void ChangeTag()
    {
        transform.tag = "GreyBlock";
    }
}
