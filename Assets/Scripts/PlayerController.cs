using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void Start()
    {
        
    }
}
