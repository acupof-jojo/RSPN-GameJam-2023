using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs ;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves   =  5f;
    [SerializeField] private float difficultyScalingFactor   =  0.75f;
    [SerializeField] private Button startWaveButton;
    [SerializeField] private GameObject waveUI;
    [SerializeField] private TextMeshProUGUI waveNumDisplay;
    [SerializeField] public static int[] waveAwards = {70, 40, 30, 30, 30, 20, 10, 0, 0, 0,
                                                0, 0, 0, 0, 0, 0, 0, 0};

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent( );  

    public static int currentWave = 1; 
    private float timeSinceLastSpawn;
    public static int enemiesAlive;
    public static int enemiesLeftToSpawn;
    private bool isSpawning;

    private void Awake()
    {
        //onEnemyDestroy.AddListener(EnemyDestroyed);
        if(enemiesAlive == 0)
        {
            startWaveButton.onClick.AddListener(StartSpawning);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        //SpawnEnemy();
        //StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame

   /* void Update()
    {
        if(enemiesAlive == 0)
        {
            
        }
        if(!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f /enemiesPerSecond) && enemiesLeftToSpawn > 0 ){ 
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++; 
            timeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0){
            EndWave();
        }
    }*/

    void FixedUpdate() {

    }

    void StartSpawning() {
        Debug.Log("Starting Wave " + currentWave+1);
        StartCoroutine(SpawnEnemy());
        waveUI.SetActive(false);


    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;

        Debug.Log("enemies alive: " + enemiesAlive);

    }
/*
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;

    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;

        StartCoroutine(StartWave());
    }
*/
  
    
    private IEnumerator SpawnEnemy()
    {
        for(int i = 0 ; i < enemyWavesArr[currentWave-1].GetLength(0) ; i++) {

            GameObject prefabToSpawn = enemyPrefabs[enemyWavesArr[currentWave-1][i] - 1]; //enemyPrefabs[2];
            Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
            enemiesAlive++;
            Debug.Log("Waiting");

            yield return new WaitForSeconds(enemiesPerSecond);

        }

        //currentWave++;
        //EventManager.main.AddMoney(award);

        waveUI.SetActive(true);
        waveNumDisplay.text = "Wave " + (currentWave);
        Debug.Log("test!");

    }


    //  1 == carrier
    //  2 == shovel
    //  3 == lumber
    //  4 == excavator
    
    static private int[] enemyWaveContent1 = {1};
    static private int[] enemyWaveContent2 = {1, 1};
    static private int[] enemyWaveContent3 = {1, 1};
    static private int[] enemyWaveContent4 = {1, 1, 1, 1};
    static private int[] enemyWaveContent5 = {2, 1, 1, 1};
    static private int[] enemyWaveContent6 = {2, 2, 1, 1, 1, 1, 1};
    static private int[] enemyWaveContent7 = {2, 1, 1, 2, 1, 1, 2, 1, 1};
    static private int[] enemyWaveContent8 = {3, 3};
    static private int[] enemyWaveContent9 = {3, 3, 3, 3, 3, 3};
    static private int[] enemyWaveContent10 = {2, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3};
    static private int[] enemyWaveContent11 = {2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3};
    static private int[] enemyWaveContent12 = {2, 3, 2, 3, 2, 3, 2, 3};
    static private int[] enemyWaveContent13 = {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3};
    static private int[] enemyWaveContent14 = {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2};
    static private int[] enemyWaveContent15 = {2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 1, 2};
    static private int[] enemyWaveContent16 = {4, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3};
    static private int[] enemyWaveContent17 = {4, 4, 3, 3, 3, 3, 3, 3};
    static private int[] enemyWaveContent18 = {4, 4, 4, 4, 3, 3};


    private int[][] enemyWavesArr = {enemyWaveContent1, enemyWaveContent2, 
    enemyWaveContent3, enemyWaveContent4, enemyWaveContent5, enemyWaveContent6, 
    enemyWaveContent7, enemyWaveContent8, enemyWaveContent9, enemyWaveContent10, 
    enemyWaveContent11, enemyWaveContent12, enemyWaveContent13, enemyWaveContent14, 
    enemyWaveContent15, enemyWaveContent16, enemyWaveContent17, enemyWaveContent18};
    

}
