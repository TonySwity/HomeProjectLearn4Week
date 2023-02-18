using UnityEngine.Events;

public class StartPanel : CanvasPanel
{
    public event UnityAction PlayButtonClick;
    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
    public override void Open()
    {
        CanvasGroup.alpha = 1f;
        Button.interactable = true;
    }
    public override void Close()
    {
        CanvasGroup.alpha = 0f;
        Button.interactable = false;
    }
}
