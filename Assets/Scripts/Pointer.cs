using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private Coin _closestCoin;

    private void FixedUpdate()
    {
        _closestCoin = _coinManager.GetClosest(transform.position);
        Debug.DrawLine(transform.position, _closestCoin.transform.position, Color.magenta);
    }
}
