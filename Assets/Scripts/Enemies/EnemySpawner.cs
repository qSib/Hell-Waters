using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState {Spawning, Waiting, Counting};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform zombieDiver;
        public Transform shark;
        public int zombieCount;
        public int sharkCount;
        public float rate;
    }

    public Wave[] waves; //Creates a list of waves.
    private int nextWave = 0;

    public Transform[] zombieSpawnPoints;
    public Transform sharkSpawn;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

    void Start()
    {
        waveCountdown = timeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }

        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {   

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            SceneManager.LoadScene("GameWon");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive() //Check whether there are any enemies left.
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Zombie") == null && GameObject.FindGameObjectWithTag("Shark") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.zombieCount; i++)
        {
            SpawnDiver(_wave.zombieDiver);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        for (int i = 0; i < _wave.sharkCount; i++)
        {
            SpawnShark(_wave.shark);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnDiver(Transform _enemy)
    {

        Transform _sp = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    void SpawnShark(Transform _enemy)
    {

        Transform _sp = sharkSpawn;
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
