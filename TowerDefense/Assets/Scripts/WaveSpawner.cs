using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {


    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    public Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex=0;
    void Update (){

        if(EnemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            //this is how to call Coroutine(Ienumerator)
            StartCoroutine(SpawnWave());

            countdown = timeBetweenWaves;
            return;
        }
        //reduce countdown by 1 every second
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        ///set the UI Text to equal to countdown
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }
    //Ienumerator from unity.collection allows function to have wait function which
    //is yield return enw WaitForSeconds(time);
    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveIndex++;

        

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);

    }
}
