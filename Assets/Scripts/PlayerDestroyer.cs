using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    [SerializeField] private int _damage = 1000000000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}
