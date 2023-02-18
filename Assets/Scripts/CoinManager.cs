using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Coin> _coins;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private String _text;
    [SerializeField] private float _minBoundSpawn = -20f;
    [SerializeField] private float _maxBoundSpawn = 20f;

    public event UnityAction CoinCollected;
    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 newPosition = new Vector3(Random.Range(_minBoundSpawn, _maxBoundSpawn), 0.5f, Random.Range(_minBoundSpawn, _maxBoundSpawn));
            Coin newCoin = Instantiate(_coinPrefab, newPosition, Quaternion.identity);
            newCoin.transform.parent = transform;
            _coins.Add(newCoin);
        }

        foreach (var item in _coins)
        {
            item.Init(() =>
            {
                CollectCoin(item);
                if (_coins.Count == 0) CoinCollected?.Invoke();
            });
        }
        
        UpdateText();
    }

    public Coin GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;
        
        for (int i = 0; i < _coins.Count; i++)
        {
            float distance = Vector3.Distance(point, _coins[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestCoin = _coins[i];
            }
        }

        return closestCoin;
    }

    private void CollectCoin(Coin coin)
    {
        _coins.Remove(coin);
        UpdateText();
    }

    private void UpdateText()
    {
        _textMeshPro.text = _text + _coins.Count;
    }
}
