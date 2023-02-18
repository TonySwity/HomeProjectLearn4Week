using UnityEngine;

public class CoinNavigator : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private Player _player;

    private Coin _closestCoin;
    private void LateUpdate()
    {
        if (_player && _coinManager)
        {
            transform.position = new Vector3(_player.transform.position.x, 1.3f, _player.transform.position.z);
            _closestCoin = _coinManager.GetClosest(transform.position);
            
            if (_closestCoin)
            {
                Vector3 toTarget = _closestCoin.transform.position - transform.position;
                Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(toTargetXZ), Time.fixedDeltaTime * 3f);
            }

            
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }

    public void InitPlayer(Player player)
    {
        _player = player;
    }

    public void InitCoinManager(CoinManager coinManager)
    {
        _coinManager = coinManager;
    }
}
