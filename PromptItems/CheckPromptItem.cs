using System.Windows.Forms;

namespace Prompt.PromptItems
{
    public class CheckPromptItem : PromptItem
    {
        public bool ThreeState { get; private set; }
        public CheckState CheckState { get; private set; }

        public CheckPromptItem(string fieldName,
                               string label,
                               bool threeState,
                               CheckState checkState,
                               bool isEnabled)
            : base(fieldName, label, isEnabled)
        {
            ThreeState = threeState;
            CheckState = checkState;
        }

        public override void Register(Form form, int rowNumber)
        {
            var newCheckBox = new CheckBox
            {
                Name = FieldName,
                Left = LabelLeftMargin,
                Top = rowNumber * RowHeight + RowsTopMargin,
                Text = FieldLabel,
                ThreeState = ThreeState,
                CheckState = CheckState,
                AutoEllipsis = true,
                AutoSize = true,
                Enabled = IsEnabled
            };

            form.Controls.Add(newCheckBox);

            if (0 == rowNumber)
            {
                newCheckBox.Select();
                newCheckBox.Focus();
            }
        }
    }
}
