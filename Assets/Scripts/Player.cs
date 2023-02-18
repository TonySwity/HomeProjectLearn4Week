using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction GameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.PickUp();
        }
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameOver?.Invoke();
        Destroy(gameObject);
    }
    
}
