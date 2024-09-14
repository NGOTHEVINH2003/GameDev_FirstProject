using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public float objectLifeTime = 1f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, objectLifeTime);
    }
}
