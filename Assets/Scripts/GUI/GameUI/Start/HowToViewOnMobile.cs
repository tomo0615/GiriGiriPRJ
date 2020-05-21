using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HowToViewOnMobile : MonoBehaviour , IHowToView
{
    private Image howToImage;

    private void Awake()
    {
        howToImage = GetComponent<Image>();
    }

    public IEnumerator ViewHowTo()
    {
        int flashCount = 3;

        while (flashCount > 0)
        {
            howToImage.enabled = true;
            yield return new WaitForSeconds(0.5f);
            howToImage.enabled = false;
            yield return new WaitForSeconds(0.5f);
            flashCount--;
        }
    }
}
