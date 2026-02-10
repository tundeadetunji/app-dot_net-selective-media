Public Interface IUiService
    Sub AwaitUserInteraction(dialog As IDialogResource)
    Sub HideDialog(dialog As IDialogResource)
    Sub InitializeDialog(dialog As IDialogResource)
    Sub ToggleEditingTextBoxes(dialog As IDialogResource, state As Boolean)
    Sub ToggleVisibilityOfHiddenControls(dialog As IDialogResource, visible As Boolean)

    Sub ShowTip(dialog As IDialogResource, t As TextBox)

End Interface
