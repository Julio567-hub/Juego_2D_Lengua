using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerControler : MonoBehaviour
{
    public float PlayerJumpForce = 20f;
    public float PlayerSpeed = 5f;
    public Sprite[] sprites;
    private int index = 0;
    public GameManager myGameManager;
    public GameObject Bullet;
    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

   
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
        myGameManager = FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, PlayerJumpForce);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
        myrigidbody2D.linearVelocity = new Vector2(PlayerSpeed, myrigidbody2D.linearVelocity.y);

    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.sprite = sprites[index];
        index++;
        if (index == 6)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.Addscore();
        }
        if (collision.gameObject.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }
}