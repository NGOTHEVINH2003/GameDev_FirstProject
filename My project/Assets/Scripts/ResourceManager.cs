using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public int blood;
    public int crystal;

    public TMP_Text woodCount;
    public TMP_Text bloodCount;
    public TMP_Text crystalCount;

    public static ResourceManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(string resourceType, int amount)
    {
        if (resourceType.ToLower() == "wood")
        {
            wood += amount;
            woodCount.text = wood.ToString();
        }
        if (resourceType.ToLower() == "blood")
        {
            blood += amount;
            bloodCount.text = blood.ToString();
        }
        if(resourceType.ToLower() == "crystal")
        {
            crystal += amount;
            crystalCount.text = crystal.ToString();
        }
    }
}
