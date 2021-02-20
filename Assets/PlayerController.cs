using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float h, width;
    bool onlyOnce = false;
    public GameObject playerHolder, mainPlayer;
    public float speed = 5f;
    
    Vector3 pos;
    Vector3  desiredPos;

    public Animator anim;
    
    
    void Start()
    {
        width = Screen.width;
        anim = mainPlayer.GetComponent<Animator>();
    }

    void Update()
    {
        
        if (PlayerManager.instance.gameStarted)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("idle", false);

            if (PlayerManager.instance.isball)
            {
                anim.SetBool("push", true);
            }
            else
            {
                anim.SetBool("push", false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                h = Input.mousePosition.x;
                pos = playerHolder.transform.localPosition;
            }
            if (Input.GetMouseButton(0))
            {
                //  h = SimpleInput.GetAxis("Horizontal");
                if (!onlyOnce)
                {
                    // an.SetBool("run",true);
                    onlyOnce = true;
                    mainPlayer.transform.localPosition = new Vector3(0f, 0f, 0f);
                }
            

            float p = (h - Input.mousePosition.x) / width;
            p *= -15;
            desiredPos = pos + new Vector3(p, 0, 0);
            desiredPos.x = Mathf.Clamp(desiredPos.x, -3f, 3f);
            playerHolder.transform.localPosition = new Vector3(desiredPos.x, desiredPos.y, playerHolder.transform.localPosition.z);
          
            }

        }
        else
        {
            anim.SetBool("idle", true);
        }

    }
}
