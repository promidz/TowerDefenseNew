using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ummi : Bosses
{
    private void Start()
    {
        bossImage.sprite = bossSprite[0];

    }

    private void Update()
    {
        AlwaysOnUpdate();

        IfItsTimeToEvolve();
        

    }

    
    public override void IfItsTimeToEvolve()
    {
        if (cooldown <= 0f && isEvolved == false && timeCanEvolve>0 && onDialog==false)
        {
            isEvolved = true;
            ChangeImage();
            StartCoroutine(SpawnSpecialEnemy(specialEnemy));
        }
    }
}