using UnityEngine;

public class MemSlot : MonoBehaviour
{
    public bool isFull;
    public string Flower1 = "Flower1";
    public string Flower2 = "Flower2";
    public string Flower3 = "Flower3";
    public string Flower4 = "Flower4";
    public string Flower5 = "Flower5";
    public int returnFlower1;
    public int returnFlower2;
    public int returnFlower3;
    public int returnFlower4;
    public int returnFlower5;
    void Start()
    {
        returnFlower1 = 0;
        isFull = false;
    }

    void Update()
    {
        checkSlot();
    }

    public void checkSlot()
    {
        if (transform.childCount != 1)
        {
            if (transform.GetChild(1).CompareTag(Flower1))
            {
                returnFlower1 = 1;
            }
            else if (transform.GetChild(1).CompareTag(Flower2))
            {
                returnFlower2 = 1;
            }
            else if (transform.GetChild(1).CompareTag(Flower3))
            {
                returnFlower3 = 1;
            }
            else if (transform.GetChild(1).CompareTag(Flower4))
            {
                returnFlower4 = 1;
            }
            else if (transform.GetChild(1).CompareTag(Flower5))
            {
                returnFlower5 = 1;
            }
        }
        else
        {
            returnFlower1 = 0;
            returnFlower2 = 0;
            returnFlower3 = 0;
            returnFlower4 = 0;
            returnFlower5 = 0;
        }
    }
}
