using UnityEngine;
using UnityEngine.UI;

namespace MiniGames
{
public class Box : MonoBehaviour
{

    private Image _image;
    private BoxCollider2D _bc2D;


    private void Awake()
    {
        _image = GetComponent<Image>();
        _bc2D = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetBox(true);
    }

    public void SetBox(bool isOpen)
    {
        if (isOpen)
        {
            _image.enabled = true;
            _bc2D.enabled = true;
        }
        else
        {
            _image.enabled = false;
            _bc2D.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}