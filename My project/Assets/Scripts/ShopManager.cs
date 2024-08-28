using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Ghost worker;
    [SerializeField] private Ghost village;
    [SerializeField] private Ghost tree;
    [SerializeField] private Ghost crystal;
    [SerializeField] private Ghost trap;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopClick(string purchaseItem)
    {
        if(purchaseItem.ToLower() == "worker")
        {
            Instantiate(worker);
        }
        if (purchaseItem.ToLower() == "village")
        {
            Instantiate(village);
        }
        if (purchaseItem.ToLower() == "tree")
        {
            Instantiate(tree);
        }
        if (purchaseItem.ToLower() == "crystal")
        {
            Instantiate(crystal);
        }
        if (purchaseItem.ToLower() == "trap")
        {
            Instantiate(trap);
        }
    }
}
