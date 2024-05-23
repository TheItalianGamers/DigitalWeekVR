using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelevisionImage : MonoBehaviour
{
    public Texture2D img;

    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite = Sprite.Create(img, new Rect(0.0f, 0.0f, img.width, img.height), Vector2.zero );
        GetComponentInChildren<Image>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
