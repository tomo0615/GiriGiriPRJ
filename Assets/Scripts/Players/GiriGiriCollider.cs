using UnityEngine;

public class GiriGiriCollider : MonoBehaviour, ITouchable
{
    public void Touch()
    {
        //Playerのボーナスを加算
        Debug.Log("Bonus!");

        this.enabled = false;
    }
}
