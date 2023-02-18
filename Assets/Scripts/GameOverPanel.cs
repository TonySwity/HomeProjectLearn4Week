using UnityEngine.Events;

public class GameOverPanel : CanvasPanel
{
    public event UnityAction ReastartButtonClick;
    protected override void OnButtonClick()
    {
        ReastartButtonClick?.Invoke();
    }
    public override void Open()
    {
        CanvasGroup.alpha = 1f;
        CanvasGroup.blocksRaycasts = true;
        Button.interactable = true;
    }
    public override void Close()
    {
        CanvasGroup.alpha = 0f;
        CanvasGroup.blocksRaycasts = false;
        Button.interactable = false;
    }
}
