using System.Windows.Forms;

namespace Prompt
{
    public abstract class PromptItem : IPromptItem
    {
        protected const int RowsTopMargin = 5;
        protected const int LabelLeftMargin = 30;
        public const int RowHeight = 25;

        public string FieldName { get; private set; }
        public string FieldLabel { get; private set; }
        public bool IsEnabled { get; private set; }

        protected PromptItem(string fieldName, string label, bool isEnabled)
        {
            FieldName = fieldName;
            FieldLabel = label;
            IsEnabled = isEnabled;
        }

        public virtual void Register(Form form, int rowNumber)
        {
            var newLabel = new Label
            {
                AutoEllipsis = true,
                Left = LabelLeftMargin,
                Top = rowNumber * RowHeight + RowsTopMargin,
                AutoSize = true,
                Text = FieldLabel
            };

            form.Controls.Add(newLabel);
        }
    }
}
