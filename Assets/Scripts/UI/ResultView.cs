using UnityEngine;

public class ResultView : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ViewResult()
    {
        this.gameObject.SetActive(true);
    }
}
