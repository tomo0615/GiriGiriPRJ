using UnityEngine;
using TMPro;
using System.Collections;

public class LevelUpView : MonoBehaviour
{
    private TextMeshProUGUI levelUpText;

    private  void Awake()
    {
        levelUpText = GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator ViewLevelUp()
    {
        int flashCount = 2;

        while(flashCount > 0)
        {
            levelUpText.text = "Level Up!";
            yield return new WaitForSeconds(0.25f);
            levelUpText.text = "";
            yield return new WaitForSeconds(0.25f);
            flashCount--;
        }
    }
}
