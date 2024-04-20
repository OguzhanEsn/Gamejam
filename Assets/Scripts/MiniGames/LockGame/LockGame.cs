using UnityEngine;
using TMPro;
using NunPlayerInput;

namespace MiniGames{
public class LockGame : MonoBehaviour
{
    public float speed = 5f; //Default 150f
    public ClockDirection _direction = ClockDirection.Clockwise;

    public int remainingLocks = 2;
    private int remainingLockPicks = 0;

    private DotDetector _dotDetector;

    private Vector2 paddleStartPos;

    [SerializeField] private Transform midlePoint, paddle;
    [SerializeField] private TextMeshProUGUI remainingLockText, remainingLockPicksText;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private GameObject mamaDots;
    [SerializeField] private LockDifficulty lockDifficulty;

    [SerializeField] private HudHandler hudHandler;
    [SerializeField] private InventoryHandler inventoryHandler;
    public GameObject winObject;

    public int RemainingLockPicks
    {
        get { return remainingLockPicks; }
        set { remainingLockPicks = value; }
    }

    public LockDifficulty LockDifficulty
    {
        get { return lockDifficulty; }
        set { lockDifficulty = value; }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void FirstStart()
    {
        ClearAllDots();
        SetPaddlePos();
        SetDifficulty();
        //remainingLocks = 3;
       // remainingLocks = Random.Range(1, 4);
        SetText();
    }

    void Awake()
    {
        paddleStartPos = paddle.position;
        _dotDetector = paddle.GetComponent<DotDetector>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckInput();
        paddle.RotateAround(midlePoint.position, Vector3.forward, speed 
        * Time.deltaTime* (int)_direction * -1);
        CheckAutomateDots();
    }

    void Update()
    {
        CheckInput();
    }

    void SetDifficulty()
    {
        switch (lockDifficulty)
        {
            case LockDifficulty.Easy:
                speed = 130f;
                CreateDots(DotType.Yellow);
                break;
            case LockDifficulty.Medium:
                speed = 150f;
                CreateDots(DotType.Yellow);
                CreateDots(DotType.Blue);
                break;
            case LockDifficulty.Hard:
                speed = 185f;
                CreateDots(DotType.Yellow);
                CreateDots(DotType.Blue);
                CreateDots(DotType.Red);
                break;
        }
    }

    void SetText()
    {
        remainingLockText.text = remainingLocks.ToString();
        remainingLockPicksText.text = "Lockpick Left: " + remainingLockPicks.ToString();
    }

    void SetPaddlePos()
    {
        paddle.position = paddleStartPos;
        paddle.rotation = Quaternion.identity;
    }

    void CheckRemainingLocks()
    {
        if(remainingLocks <= 0)
        {
            //Win
            winObject.GetComponent<TestObje>().isOpen = true;
            Debug.Log("WinCond");
            hudHandler.CloseMiniGameUI();
            hudHandler.InventoryOpenClose();
            hudHandler.StopMovement(true);
        }
        if(remainingLockPicks <= 0)
        {
            //Lose
            Debug.Log("LoseCond");
            hudHandler.StopMovement(false);
            hudHandler.CloseMiniGameUI();
        }
    }

    void CheckInput()
    {
        if(InputHandler.instance.GetInteractInput())
        {
            Debug.Log("OYNAAAA is pressed");
            switch (_dotDetector.GetCurrentDotType())
            {
                case DotType.Empty:
                Debug.Log("Empty");
                    remainingLockPicks--;
                    inventoryHandler.RemoveItem();
                    SetText();
                    SetPaddlePos();
                    CheckRemainingLocks();
                    //ResetPaddlePos;
                    break;
                case DotType.Yellow:
                    Debug.Log("Yellow");
                    remainingLocks--;
                    _dotDetector._currentDotCollider.gameObject.SetActive(false);
                    ClearAllDots();
                    SetDifficulty();
                    SetText();
                    SetPaddlePos();
                    CheckRemainingLocks();
                    //ResetPaddlePos;
                    break;
            }
        }

        if(InputHandler.instance.GetQButtonInput())
        {
            speed *= -1f;
            Debug.Log("Interact is pressed");
        }

    }

     
    void ClearAllDots()
    {
        foreach (Transform child in mamaDots.transform)
        {
            Destroy(child.gameObject);
        }
    }
    void CheckAutomateDots()
    {
        if(_dotDetector._currentDotType  == DotType.Empty)
        {
            //ResetPaddlePos;
            return;
        }


        if(_dotDetector.GetCurrentDotType() == DotType.Blue)
        {
            speed *= 1.5f;
            _dotDetector._currentDotCollider.gameObject.SetActive(false);
            return;
        }else if(_dotDetector.GetCurrentDotType() == DotType.Red)
        {
            remainingLockPicks--;
            inventoryHandler.RemoveItem();
            _dotDetector._currentDotCollider.gameObject.SetActive(false);
            CheckRemainingLocks();
            SetPaddlePos();
            SetText();
            return;
        }
    }


    void CreateDots(DotType dotType)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * 170f;
        Vector3 spawnPosition = midlePoint.position + new Vector3(randomPoint.x, randomPoint.y, 0);

        // Yeni objeyi yarat ve dairesel yörüngeye yerleştir
        GameObject newObject = Instantiate(dotPrefab, spawnPosition, Quaternion.identity);
        newObject.transform.SetParent(mamaDots.gameObject.transform);
        newObject.GetComponent<Dot>().dotType = dotType;
        //newObject.GetComponent<Dot>().SetDotType(dotType);

        //Create Dots
    }


}

public enum LockDifficulty
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}
public enum ClockDirection
{
    Clockwise = 1,
    CounterClockwise = -1
}

}