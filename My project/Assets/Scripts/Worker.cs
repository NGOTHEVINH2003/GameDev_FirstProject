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


    GameObject bloodAlter;
    // Start is called before the first frame update
    void Start()
    {
        bloodAlter = GameObject.FindGameObjectWithTag("Altar");
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

            if(Vector3.Distance(transform.position, bloodAlter.transform.position) <= 1f)
            {
                ResourceManager.instance.SaccrificeWorker();
                Destroy(gameObject);
            }
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
                    ResourceManager.instance.AddResource(currentResource.resourceType, collectAmount);
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
