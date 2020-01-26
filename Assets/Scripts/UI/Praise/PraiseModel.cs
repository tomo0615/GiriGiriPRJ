using UnityEngine;

public class PraiseModel
{
    public string GetPraiseWord(string[] wordTable)
    { 
        return wordTable[GetRamdomValue(0, wordTable.Length)];
    }

    private int GetRamdomValue(int minimum, int max)
    {
        return Random.Range(minimum, max);
    }
}
