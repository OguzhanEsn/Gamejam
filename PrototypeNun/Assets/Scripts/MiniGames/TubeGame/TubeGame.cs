using UnityEngine;
using NunPlayerInput;
using Random = UnityEngine.Random;
using Unity.Mathematics;

namespace MiniGames{
public class TubeGame : MonoBehaviour
{
    [SerializeField] private GameObject _boxGO;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private float speed = 0.5f;

    [SerializeField] private HudHandler hudHandler;
    
    public GameObject winObject;
    private Bounds _bounds;

    private float _minY, _maxY;
    private int _direction = 1; // Hareket yönü

    private int _chances = 1;

    public int Chances
    {
        get { return _chances; }
        set { _chances = value; }
    }

    private int tubeGames = 3;


    [SerializeField] private BoxDetector paddleDet;
    private Transform _paddleTransform;

    private void Awake()
    { 
       // _boxCollider2D = GetComponent<BoxCollider2D>();
        _bounds.size = _boxCollider2D.bounds.size;
        _paddleTransform = paddleDet.transform;

        _minY = _bounds.min.y  + _paddleTransform.localScale.y / 2;
        _maxY = _bounds.max.y + _paddleTransform.localScale.y / 2;

        Debug.Log("MinY: " + _minY + " MaxY: " + _maxY);
    }
    // Start is called before the first frame update
    void Start()
    {
      //  SetPaddlePos();
     //   RandomBoxPos();
        
    }

    public void FirstStart()
    {
        _chances = 1;
        tubeGames = 3;
        SetPaddlePos();
        RandomBoxPos();
        winObject.GetComponent<HumanoidObject>().IsStolen = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("TubeGame Update");

        if (InputHandler.instance.GetInteractInput())
        {
            if(paddleDet.IsBoxFull())
            {
                //Win
                tubeGames--;
                CheckWinLoseCond();
                SetPaddlePos();
                RandomBoxPos();
            }else 
            {
                //Lose
                _chances --;
                CheckWinLoseCond();

                SetPaddlePos();
            }

        }
        GenericUpDownMovement();
    }

    void CheckWinLoseCond()
    {
        if(_chances == 0)
        {
            //Lose
            hudHandler.CloseMiniGameUI();
            hudHandler.StopMovement(false);
            Debug.Log("Lose");
        }

        if(tubeGames == 0)
        {
            //Win
            hudHandler.CloseMiniGameUI();
            hudHandler.InventoryOpenClose();
            hudHandler.StopMovement(true);
            winObject.GetComponent<HumanoidObject>().IsStolen = true;
            Debug.Log("Win");
        }
    }

    void SetPaddlePos()
    {
        _paddleTransform.localPosition = new Vector3(_paddleTransform.localPosition.x, _maxY, _paddleTransform.localPosition.z);
    }

    void RandomBoxPos()
    {
        float randomY = Random.Range(_minY, _maxY);
        _boxGO.transform.localPosition = new Vector3(_boxGO.transform.localPosition.x, randomY, _boxGO.transform.localPosition.z);
    }

    void GenericUpDownMovement()
    {
        float newY = _paddleTransform.localPosition.y + speed * Time.unscaledDeltaTime * _direction;

        // Check TtHE boundaries
        if (newY < _minY)
        {
            newY = _minY;
            _direction = 1; // Go Up
        }
        else if (newY > _maxY)
        {
            newY = _maxY;
            _direction = -1; // Go Down
        }
        
        _paddleTransform.localPosition = new Vector3(_paddleTransform.localPosition.x, newY, _paddleTransform.localPosition.z);


    }
}


}