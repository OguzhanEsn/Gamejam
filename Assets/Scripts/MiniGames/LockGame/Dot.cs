using UnityEngine.UI;
using UnityEngine;

namespace MiniGames{
public class Dot : MonoBehaviour
{
    private Image _image;
    public DotType dotType;

    public void SetDotType(DotType type)
    {
        dotType = type;
        
        Debug.Log("Setting dot type to: " + type);
        //DEFINEATLY CHANGE BELOW SWITCH TO A SO
        switch (type)
        {
            case DotType.Red:
                _image.color = Color.red;
                break;
            case DotType.Blue:
                _image.color = Color.blue;
                break;
            case DotType.Yellow:
                _image.color = Color.yellow;
                break;
            case DotType.Empty:
                _image.color = Color.white;
                break;
        }
    }

    void Awake()
    {
        _image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetDotType(dotType);
    }

    void OnEnable()
    {
        SetDotType(dotType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}