using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{

    public float speed;
    public float minX, minY , maxX, maxY;

    Vector3 currentTarget;

    public GameObject bloodVfx;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = getRandPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
            currentTarget = getRandPos();
        }
    }

    Vector3 getRandPos()
    {
        Vector3 pos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Altar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(collision.tag == "Trap")
        {
            Destroy(collision.gameObject);
            Instantiate(bloodVfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collision.tag == "Human")
        {
            Destroy(gameObject);
            Instantiate(bloodVfx, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
