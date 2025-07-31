using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class monedaanimation : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer mySpriteRenderer;
    private int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.sprite = sprites[index];
        index++;
        if (index == 8)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
}
