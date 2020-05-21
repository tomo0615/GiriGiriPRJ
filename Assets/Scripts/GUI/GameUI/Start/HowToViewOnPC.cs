using System.Collections;
using UnityEngine;
using TMPro;

public class HowToViewOnPC : MonoBehaviour , IHowToView
{
    private TextMeshProUGUI howToText;

    private void Awake()
    {
        howToText = GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator ViewHowTo()
    {
        int flashCount = 3;

        while (flashCount > 0)
        {
            howToText.text = "< Dodge! >";
            yield return new WaitForSeconds(0.5f);
            howToText.text = "";
            yield return new WaitForSeconds(0.5f);
            flashCount--;
        }
    }
}
