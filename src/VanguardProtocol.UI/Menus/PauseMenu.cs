namespace VanguardProtocol.UI.Menus;

public sealed class PauseMenu
{
    private readonly UiFocusGroup _focus = new();
    public string Title { get; } = "PauseMenu";
    public bool IsOpen { get; private set; }
    public UiFocusGroup Focus => _focus;
    public string? LastAction { get; private set; }

    public PauseMenu()
    {
        _focus.Add(new UiButton { Id = "primary", Label = "Continue", OnClick = () => LastAction = "primary" });
        _focus.Add(new UiButton { Id = "secondary", Label = "Options", OnClick = () => LastAction = "secondary" });
        _focus.Add(new UiButton { Id = "back", Label = "Back", OnClick = () => LastAction = "back" });
    }

    public void Open() { IsOpen = true; LastAction = null; }
    public void Close() => IsOpen = false;
    public void Handle(UiNav nav) { if (IsOpen) _focus.Navigate(nav); }
}
