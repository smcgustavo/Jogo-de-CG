using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform orangePrefab;
    public Transform bluePrefab;
    public Transform purplePrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 1;
    public Text waveCountdownText;
    public Text waveIndexCounter;
    public string serie = "PP----PPP-----OO-----O-O-O-PP";
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Floor(countdown).ToString() + " Segundos";
        waveIndexCounter.text = "Wave: " + waveNumber.ToString();

    }
    IEnumerator SpawnWave() {

        for (int i = 0; i < waveNumber; i++)
        {
            
            SpawnEnemy(serie[count]);
            if (serie[count] == '-')
            {
                yield return new WaitForSeconds(8f);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
        waveNumber++;
    }
    void SpawnEnemy(char monster)
    {
        switch (monster) {
            case 'O':
                Instantiate(orangePrefab, orangePrefab.position, orangePrefab.rotation);
                break;

            case 'B':
                Instantiate(bluePrefab, bluePrefab.position, bluePrefab.rotation);
                break;

            case 'P':
                Instantiate(purplePrefab, purplePrefab.position, purplePrefab.rotation);
                break;
            case '-':
                break;
        }
        count++;
    }
}
