using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager;
    
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.linearVelocity = new Vector2(bulletSpeed, myrigidbody2D.linearVelocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        else if (collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            myGameManager.Addscore();
            Destroy(gameObject);
        }

        
    }
}
