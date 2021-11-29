namespace VanguardProtocol.UI;

public enum UiNav : byte { Up, Down, Left, Right, Confirm, Cancel }

public sealed class UiButton
{
    public required string Id { get; init; }
    public required string Label { get; init; }
    public bool Enabled { get; set; } = true;
    public Action? OnClick { get; init; }
}

public sealed class UiFocusGroup
{
    private readonly List<UiButton> _buttons = new();
    private int _index;
    public IReadOnlyList<UiButton> Buttons => _buttons;
    public int FocusIndex => _index;
    public UiButton? Focused => _buttons.Count == 0 ? null : _buttons[Math.Clamp(_index, 0, _buttons.Count - 1)];
    public void Add(UiButton button) => _buttons.Add(button);

    public void Navigate(UiNav nav)
    {
        if (_buttons.Count == 0)
            return;
        if (nav is UiNav.Up or UiNav.Left)
            _index = (_index - 1 + _buttons.Count) % _buttons.Count;
        else if (nav is UiNav.Down or UiNav.Right)
            _index = (_index + 1) % _buttons.Count;
        else if (nav == UiNav.Confirm)
            Focused?.OnClick?.Invoke();
    }
}
