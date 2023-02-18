using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _playerPref;
    [SerializeField] private CoinNavigator _coinNavigatorPref;
    [SerializeField] private StartPanel _startPanel;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private CameraMove _cameraMove;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private RawImage _rawFinishImage;

    private Player _tempPlayer;
    private void OnEnable()
    {
        _startPanel.PlayButtonClick += OnPlayButtonClick;
        _gameOverPanel.ReastartButtonClick += OnRestartButtonClick;
        _coinManager.CoinCollected += OnFinished;

    }

    private void OnDisable()
    {
        _startPanel.PlayButtonClick -= OnPlayButtonClick;
        _gameOverPanel.ReastartButtonClick -= OnRestartButtonClick;
        _coinManager.CoinCollected += OnFinished;
    }

    private void Start()
    {
        _rawFinishImage.gameObject.SetActive(false);
        _gameOverPanel.Close();
        Time.timeScale = 0f;
        _startPanel.Open();
    }

    private void OnPlayButtonClick()
    {
        _startPanel.Close();
        StartGame();
    }
    
    private void StartGame()
    {
        Time.timeScale = 1f;
        Player newPlayer = Instantiate(_playerPref, transform.position, Quaternion.identity);
        CoinNavigator newCoinNavigator = Instantiate(_coinNavigatorPref, new Vector3(transform.position.x, 1.3f, transform.position.z), Quaternion.identity);
        newCoinNavigator.InitPlayer(newPlayer);
        newCoinNavigator.InitCoinManager(_coinManager);
        _cameraMove.InitPlayer(newPlayer);
        newPlayer.GetComponent<PlayerMove>().InitCameraCenter(_cameraMove.transform);
        newPlayer.GameOver += OnGameOver;
        _tempPlayer = newPlayer;
    }

    private void OnRestartButtonClick()
    {
        _gameOverPanel.Close();
        StartGame();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        _tempPlayer.GameOver -= OnGameOver;
        _gameOverPanel.Open();
    }

    private void OnFinished()
    {
        _rawFinishImage.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
