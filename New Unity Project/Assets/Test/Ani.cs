using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani : MonoBehaviour
{
    List<Sprite> Sprites = new List<Sprite> ();
    int a = 0,b=0;
    public int Zhenshu;
    private SpriteRenderer spriterenderer;

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        Sprites.Add(Resources.Load<Sprite>("001") as Sprite);
        for (int i = 1; i <= Zhenshu; i++)
        {
            if (i < 10)
            {
                Sprites.Add(Resources.Load<Sprite>("Ani/00" + i.ToString()));
            }
            else if (i < 100)
            {
                Sprites.Add(Resources.Load<Sprite>("Ani/0" + i.ToString()));
            }
            else
            {
                Sprites.Add(Resources.Load<Sprite>("Ani/" + i.ToString()));
            }
        }
    }

    void FixedUpdate()
    {
        if (b == 2)
        {
            a++;
            if (a <= Zhenshu)
            {
                spriterenderer.sprite = Sprites[a];
            }
            else
            {
                Destroy(spriterenderer);
            }
            b = 0;
        }
        else
        {
        }
        b++;
    }
}