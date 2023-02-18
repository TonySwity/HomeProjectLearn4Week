using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Action _pickCoin;

    public void PickUp()
    {
        _pickCoin();
        Destroy(gameObject);
    }

    internal void Init(Action action)
    {
        _pickCoin = action;
    }
}
