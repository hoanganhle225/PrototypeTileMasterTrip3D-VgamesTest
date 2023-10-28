using UnityEngine;

public class TileController : MonoBehaviour
{
    public bool isSelected = false;
    public GameObject MemSlot;
    public GameManager gameManager;
    public Rigidbody tileRb;
    public AudioSource audioSource;
    public AudioClip clickTile;
    public GameObject gameManagerObject;

    void Start()
    {
        MemSlot = GameObject.Find("MemSlots");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManagerObject = GameObject.Find("GameManager");
        transform.parent = gameManagerObject.transform;
    }

    void Update()
    {
        checkTotalTile();
    }

    public void checkTotalTile()
    {
        if (gameManager.Flower1 == 3 && isSelected == true && gameObject.CompareTag("Flower1"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.Flower2 == 3 && isSelected == true && gameObject.CompareTag("Flower2"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.Flower3 == 3 && isSelected == true && gameObject.CompareTag("Flower3"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.Flower4 == 3 && isSelected == true && gameObject.CompareTag("Flower4"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.Flower5 == 3 && isSelected == true && gameObject.CompareTag("Flower5"))
        {
            DestroyCommandFromGameManager();
        }
    }
    
    private void OnMouseDown()
    {
        if (gameManager.gameIsStart == true && Time.timeScale != 0)
        {
            for (int i = 0; i < MemSlot.transform.childCount; i++)
            {
                if (MemSlot.transform.GetChild(i).GetComponent<MemSlot>().isFull == false && isSelected == false)
                {
                    if (transform.rotation != Quaternion.identity)
                    {
                        transform.rotation = Quaternion.identity;
                    }
                    audioSource.PlayOneShot(clickTile);
                    isSelected = true;
                    transform.position = MemSlot.transform.GetChild(i).transform.position;
                    transform.parent = MemSlot.transform.GetChild(i).transform;
                    MemSlot.transform.GetChild(i).GetComponent<MemSlot>().isFull = true;
                    break;
                }
            }
        }
    }
    public void DestroyCommandFromGameManager()
    {
        gameObject.GetComponentInParent<MemSlot>().isFull = false;
        Destroy(gameObject);
    }
}
