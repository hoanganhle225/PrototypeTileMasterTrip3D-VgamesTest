using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip GetPoint;
    public int level;
    public bool gameIsStart = false;
    public bool startGame = false;
    public bool gameIsLose = false;

    public GameObject MemSlot;
    public int Flower1;
    public int Flower2;
    public int Flower3;
    public int Flower4;
    public int Flower5;

    public int totalTile;
    public int totalSpawnTile;
    [SerializeField] int totalSlotIsFull;

    [SerializeField] float UserPoint = 0;
    public TextMeshProUGUI userPointText;
    [SerializeField] int userLv;
    public TextMeshProUGUI userLvText;
    [SerializeField] int TimeCounter;
    public TextMeshProUGUI timeCounterText;
    private float timeCell;
    private float timeMin = 2;
    private float timeSec = 59;

    public GameObject winGamePopup;
    public GameObject loseGamePopup;
    public GameObject PauseMenu;
    public TextMeshProUGUI winGameText;
    public TextMeshProUGUI LoseGameText;
    void Start()
    {
        startTime();
        level = 1;
        Flower1 = 0;
        StartGame();
    }

    void Update()
    {
        TileCal();
        checkTileAndGetPoint();
        Win();
        Lose();
        TimeCounterDown();
        userLvText.text = level.ToString();
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        startGame = true;
    }
    public void TileCal()
    {
        totalSpawnTile = GameObject.FindGameObjectsWithTag("Flower1").Length
            + GameObject.FindGameObjectsWithTag("Flower2").Length
            + GameObject.FindGameObjectsWithTag("Flower3").Length
            + GameObject.FindGameObjectsWithTag("Flower4").Length
            + GameObject.FindGameObjectsWithTag("Flower5").Length;
        Flower1 = 0;
        Flower2 = 0;
        Flower3 = 0;
        Flower4 = 0;
        Flower5 = 0;
        for (int i = 0; i < MemSlot.transform.childCount; i++)
        {
            Flower1 += MemSlot.transform.GetChild(i).GetComponent<MemSlot>().returnFlower1;
            Flower2 += MemSlot.transform.GetChild(i).GetComponent<MemSlot>().returnFlower2;
            Flower3 += MemSlot.transform.GetChild(i).GetComponent<MemSlot>().returnFlower3;
            Flower4 += MemSlot.transform.GetChild(i).GetComponent<MemSlot>().returnFlower4;
            Flower5 += MemSlot.transform.GetChild(i).GetComponent<MemSlot>().returnFlower5;
        }
        
    }
    public void startTime()
    {
        timeMin = 2;
        timeSec = 59;
    }
    public void checkTileAndGetPoint()
    {
        if (totalSpawnTile < totalTile)
        {
            audioSource.PlayOneShot(GetPoint);
            totalTile = totalSpawnTile;
            UserPoint += 10;
            userPointText.text = UserPoint.ToString();
        }
    }

    public void Win()
    {
        if (gameIsStart == true && totalSpawnTile == 0)
        {
            winGamePopup.SetActive(true);
            winGameText.text = UserPoint.ToString();
            gameIsStart = false;
        }
    }
    public void Lose()
    {
        
        totalSlotIsFull = 0;
        for (int i = 0; i < MemSlot.transform.childCount; i++)
        {
            if (MemSlot.transform.GetChild(i).GetComponent<MemSlot>().isFull == true)
            {
                totalSlotIsFull += 1;
            }
        }
        if (gameIsStart && totalSlotIsFull == 7)
        {
            gameIsStart = false;
            loseGamePopup.SetActive(true);
        }
        if (timeMin < 0)
        {
            gameIsStart = false;
            loseGamePopup.SetActive(true);
        }
        LoseGameText.text = UserPoint.ToString();
    }
    public void TimeCounterDown()
    {
        if (gameIsStart)
        {
            timeCell += Time.deltaTime;
            if (timeCell >= 1)
            {
                timeSec -= timeCell;
                timeCell = 0;
            }
            if (timeSec <= 0)
            {
                timeSec = 60;
                timeMin -= 1;
            }
            timeSec = Mathf.RoundToInt(timeSec);
            if (timeSec < 10)
            {
                timeCounterText.text = "0" + timeMin.ToString() + ":0" + timeSec.ToString();
            }
            else
            {
                timeCounterText.text = "0" + timeMin.ToString() + ":" + timeSec.ToString();
            }
        }
        else timeCounterText.text = "00:00";
    }
   
    public void NextLevel()
    {
        startTime();
        level += 1;
        if (level > 3) level = 1;
        startGame = true;
        Time.timeScale = 1;
        winGamePopup.SetActive(false);
    }
}
