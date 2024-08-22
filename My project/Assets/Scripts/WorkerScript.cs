using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Worker : MonoBehaviour
{
    private bool isSelected;
    public LayerMask resLayer;
    public float collectDistance;
    Resource currentResource;

    [SerializeField]private float timeBetweenCollect;
    float nextCollectTime;
    [SerializeField]private int collectAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            //when user is selected 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
        else
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resLayer);
            if(col != null && currentResource == null)
            {
                currentResource = col.GetComponent<Resource>();
            }
            else
            {
                currentResource = null;
            }

            if(currentResource != null)
            {
                if(Time.time > nextCollectTime)
                {
                    nextCollectTime = Time.time + timeBetweenCollect;
                    currentResource.resourceAmount -= collectAmount;
                }
            }

        }
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    private void OnMouseUp() 
    { 
        isSelected = false;
    }

}
