using UnityEngine;


namespace MiniGames
{
public class BoxDetector : MonoBehaviour
{
    private bool isBoxFull = false;

    public bool IsBoxFull()
    {
        return isBoxFull;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MGBox"))
        {
            isBoxFull = true;
            Debug.Log("Box is full");
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MGBox"))
        {
            isBoxFull = false;
            Debug.Log("Box is empty");
        }
    }
    
}
}