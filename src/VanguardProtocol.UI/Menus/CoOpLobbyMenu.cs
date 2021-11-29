namespace VanguardProtocol.UI.Menus;

public sealed class CoOpLobbyMenu
{
    private readonly UiFocusGroup _focus = new();
    public string Title { get; } = "CoOpLobbyMenu";
    public bool IsOpen { get; private set; }
    public UiFocusGroup Focus => _focus;
    public string? LastAction { get; private set; }

    public CoOpLobbyMenu()
    {
        _focus.Add(new UiButton { Id = "primary", Label = "Continue", OnClick = () => LastAction = "primary" });
        _focus.Add(new UiButton { Id = "secondary", Label = "Options", OnClick = () => LastAction = "secondary" });
        _focus.Add(new UiButton { Id = "back", Label = "Back", OnClick = () => LastAction = "back" });
    }

    public void Open() { IsOpen = true; LastAction = null; }
    public void Close() => IsOpen = false;
    public void Handle(UiNav nav) { if (IsOpen) _focus.Navigate(nav); }
}
