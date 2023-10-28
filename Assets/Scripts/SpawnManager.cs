using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] tilePrefabs;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    void Update()
    {
        checkTile();
    }
    public void checkTile()
    {
        if (gameManager.startGame == true && gameManager.gameIsStart == false)
        {
            gameManager.startGame = false;
            gameManager.gameIsStart = true;
            SpawnTile();
            gameManager.totalSpawnTile = GameObject.FindGameObjectsWithTag("Flower1").Length
                + GameObject.FindGameObjectsWithTag("Flower2").Length
                + GameObject.FindGameObjectsWithTag("Flower3").Length
                + GameObject.FindGameObjectsWithTag("Flower4").Length
                + GameObject.FindGameObjectsWithTag("Flower5").Length;
            gameManager.totalTile = gameManager.totalSpawnTile;
        }
    }

    void SpawnTile()
    {
        for (int i = 0; i < (gameManager.level + 2); i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Vector3 randomPoint = GetRandomPointInQuad(point1.transform.position, point2.transform.position, point3.transform.position, point4.transform.position);
                Instantiate(tilePrefabs[i], randomPoint, transform.rotation);
            }
        }
    }
    Vector3 GetRandomPointInQuad(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        float u = Random.Range(0f, 1f);
        float v = Random.Range(0f, 1f);

        if (u + v > 1f)
        {
            u = 1f - u;
            v = 1f - v;
        }
        Vector3 point = (1 - u - v) * p1 + u * p2 + v * p3;
        return point;
    }
}
