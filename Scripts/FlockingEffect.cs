
//The script is the manager of the books as enemies. It will generate the enemies and giving them the proper moving behaviour
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingEffect : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float xMin, xMax, yMin, yMax, zMin, zMax;
    public GameObject myGoal;
    public int numEnemies = 4;
    public int randomness = 600;
    static public int tankSize = 6;
    public static GameObject[] allEnemies;
    public  Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {

        //define The space that the enemies can move. This is in front of the camera
        xMin = -7f;
        xMax = 7f;
        yMin = -4f;
        yMax = 4f;
        zMin = 0f;
        zMax = 8f;

        //generate The Enemies and attach them a moving behaviour through unity editor
        allEnemies = new GameObject[numEnemies];
        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            allEnemies[i] = (GameObject)Instantiate(EnemyPrefab, pos, Quaternion.identity);
            allEnemies[i].transform.parent = transform;
            allEnemies[i].tag = "Enemy";
            allEnemies[i].transform.position = pos;
            allEnemies[i].transform.rotation = Quaternion.identity;
            allEnemies[i].name = "enemy" + i;

        }

    }

    // Update is called once per frame
    void Update()
    {
        //some times the enemies go towards random Points in the space
        if (Random.Range(0, 1000) < 300)
        {
            goalPos = myGoal.transform.position;
        }


    }
}
