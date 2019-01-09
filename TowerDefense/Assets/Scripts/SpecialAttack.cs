using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAttack : MonoBehaviour {
    [SerializeField]
    public Image bossImages;
    public Sprite[] bossSprite;

    public float countdownTilEvolve=0;
    public float TimeBetweenEvolve;
    public float evolvedTime;

    public bool isEvolved;

    public void Start()
    {
        
        
    countdownTilEvolve = TimeBetweenEvolve;
        
        Debug.Log(countdownTilEvolve);
    }
    public void Update()
    {

        if (countdownTilEvolve < 0f)
        {
            
            StartCoroutine(Evolve());
            countdownTilEvolve = TimeBetweenEvolve;
            return;
        }
        if (isEvolved == false)
        {

            countdownTilEvolve -= Time.deltaTime;
        }
        Debug.Log(countdownTilEvolve);
    }
    IEnumerator Evolve()
    {
        isEvolved = true;
        bossImages.sprite = bossSprite[1];
        yield return new WaitForSeconds(evolvedTime);
        bossImages.sprite = bossSprite[0];
        isEvolved = false;
    }

}
