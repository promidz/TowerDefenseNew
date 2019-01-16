using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bosses : MonoBehaviour {
    [SerializeField]
    private float timeBetweenChange=2;
    [SerializeField]
    private float cooldown=8f;
    [SerializeField]
    Text changeCooldown;

    [SerializeField]
    Image bossImage;

    [SerializeField]
    Sprite[] bossSprite;

    private void Start()
    {
        bossImage.sprite = bossSprite[0];
        
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0f, Mathf.Infinity);
        changeCooldown.text = "DANGER: "+string.Format("{0:00.00}", cooldown);

        if(cooldown <= 0)
        {
            ChangeImage();

        }
    }
    public void ChangeImage() {

        bossImage.sprite = bossSprite[1];

    }
    IEnumerator 

}
