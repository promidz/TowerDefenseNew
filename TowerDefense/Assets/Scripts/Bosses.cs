using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bosses : MonoBehaviour {

    public bool onDialog;
    [SerializeField]
    protected float timeBetweenChange=2;
    [SerializeField]
    protected float cooldown=8f;
    [SerializeField]
    protected Text changeCooldown;

    [SerializeField]
    protected Image bossImage;

    [SerializeField]
    protected Sprite[] bossSprite;

    protected bool isEvolved = false;
    [SerializeField]
    protected Transform spawnPoint;

    [SerializeField]
    protected GameObject specialEnemy;

    [SerializeField]
    protected int specialEnemyCount;

    [SerializeField]
    protected float spawnDelay;

    [SerializeField]
    WaveSpawner wavespawner;

    [SerializeField]
    protected int timeCanEvolve;

    //private void Start()
    //{
    //    bossImage.sprite = bossSprite[0];
        
    //}

    //private void Update()
    //{
    //    cooldown -= Time.deltaTime;
    //    cooldown = Mathf.Clamp(cooldown, 0f, Mathf.Infinity);
    //    changeCooldown.text = "DANGER: "+string.Format("{0:00.00}", cooldown);

    //    if(cooldown <= 0)
    //    {
    //        ChangeImage();

    //    }
    //}
    public void ChangeImage() {

        bossImage.sprite = bossSprite[1];
        

    }

    public void AlwaysOnUpdate() {
        if (onDialog == false)
        {
            cooldown -= Time.deltaTime;
            cooldown = Mathf.Clamp(cooldown, 0f, Mathf.Infinity);
            changeCooldown.text = "DANGER: " + string.Format("{0:00.00}", cooldown);
        }
    }
    public abstract void IfItsTimeToEvolve();
    protected IEnumerator SpawnSpecialEnemy(GameObject specialEnemy)
    {
        for (int i = 0; i < specialEnemyCount; i++)
        {
            Debug.Log(specialEnemyCount);
            Instantiate(specialEnemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnDelay);
            Debug.Log(i);
        }
        //emiesAlive += specialEnemyCount;
        isEvolved = false;
        cooldown = timeBetweenChange;
        wavespawner.setEnemiesAlive(wavespawner.getEnemiesAlive() + specialEnemyCount);
        timeCanEvolve--;

    }


}
