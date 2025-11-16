Public Interface IUiService
    Sub AwaitUserInteraction(dialog As IDialogResource)
    Sub HideDialog(dialog As IDialogResource)
    Sub InitializeDialog(dialog As IDialogResource)
    Sub ToggleEditingTextBoxes(dialog As IDialogResource, state As Boolean)
    Sub ToggleVisibilityOfHiddenControls(dialog As IDialogResource, visible As Boolean)
End Interface
