using System;
using System.Windows.Forms;

namespace Prompt.PromptItems
{
    public class TextPromptItem : PromptItem
    {
        public string ValidationMask { get; private set; }
        public Type ValidationType { get; private set; }
        public string InitialValue { get; private set; }

        public TextPromptItem(string fieldName,
                              string label,
                              string validationMask,
                              Type validationType,
                              string initialValue,
                              bool isEnabled)
            : base(fieldName, label, isEnabled)
        {
            ValidationMask = validationMask;
            ValidationType = validationType;
            InitialValue = initialValue;
        }

        public override void Register(Form form, int rowNumber)
        {
            base.Register(form, rowNumber);

            var newTextBox = new MaskedTextBox
            {
                Name = FieldName,
                BeepOnError = true,
                Left = form.Width / 2,
                Top = rowNumber * RowHeight + RowsTopMargin,
                Mask = ValidationMask,
                AllowPromptAsInput = true,
                PromptChar = ' ',
                HidePromptOnLeave = true,
                Text = InitialValue,
                ValidatingType = ValidationType,
                ReadOnly = !IsEnabled
            };

            // ReSharper disable PossibleNullReferenceException
            newTextBox.GotFocus += (sender, args) => (sender as MaskedTextBox).SelectAll();
            // ReSharper restore PossibleNullReferenceException

            form.Controls.Add(newTextBox);

            if (0 == rowNumber)
            {
                newTextBox.Select();
            }
        }
    }
}
