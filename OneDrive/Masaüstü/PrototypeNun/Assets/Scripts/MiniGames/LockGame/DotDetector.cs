using UnityEngine;

namespace MiniGames
{
    
public class DotDetector : MonoBehaviour
{
    [HideInInspector] public DotType _currentDotType;
    [HideInInspector] public Collider2D _currentDotCollider;

    void Start()
    {
       // SetColors();
       _currentDotType = DotType.Empty;
    }
    public DotType GetCurrentDotType()
    {
        return _currentDotType;
    }

    void SetColors()
    {
        switch (_currentDotType)
        {
            case DotType.Red:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case DotType.Blue:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case DotType.Yellow:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case DotType.Empty:
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        _currentDotType = other.GetComponent<Dot>().dotType;
        _currentDotCollider = other;
        Debug.Log("Current Dot Type: " + _currentDotType);
        //_currentDotType = //other.GetComponent<>
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _currentDotCollider = null;
        _currentDotType = DotType.Empty;
    }

    void Update()
    {
       // if(_currentDotType == DotType.Empty) return;
       // Debug.Log("Current Dot Type: " + _currentDotType);

    }

}

     
public enum DotType
{

    Red = 0,
    Blue = 1,
    Yellow = 2,
    Empty = 3
}
}