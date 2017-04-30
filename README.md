# PromptForm
Simple windows forms library for showing dialogs with several input fields.

Example of usage:

```
new PromptForm(
    "Test",
    new List<IPromptItem>
    {
        new TextPromptItem("text1", "Text 1", null, typeof(string), "Text 1 value", true),
        new CheckPromptItem("check1", "Check", false, CheckState.Checked, true),
        new TextPromptItem("text2", "Text 2", null, typeof(string), "Text 2 value", false),
        new ComboBoxPromptItem("combo1", "Combo 1", new object[] { "1", "2", "3" }, 0, false, true)
    }).
    ShowDialog();
```
