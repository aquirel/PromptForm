using System;
using System.Windows.Forms;

namespace Prompt.PromptItems
{
    public class ComboBoxPromptItem : PromptItem
    {
        public object[] Items { get; private set; }
        public int? InitialValueIndex { get; private set; }
        public bool Editable { get; private set; }

        public ComboBoxPromptItem(string fieldName,
                                  string label,
                                  object[] items,
                                  int? initialValueIndex,
                                  bool editable,
                                  bool isEnabled)
            : base(fieldName, label, isEnabled)
        {
            if (null == items)
            {
                throw new ArgumentNullException("items");
            }

            Items = items;
            InitialValueIndex = initialValueIndex;
            Editable = editable;
        }

        public override void Register(Form form, int rowNumber)
        {
            base.Register(form, rowNumber);

            var newComboBox = new ComboBox
            {
                Name = FieldName,
                Left = form.Width / 2,
                Top = rowNumber * RowHeight + RowsTopMargin,
                Enabled = IsEnabled,
                DropDownStyle = Editable ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList
            };

            foreach (var item in Items)
            {
                newComboBox.Items.Add(item);
            }

            if (InitialValueIndex.HasValue)
            {
                newComboBox.SelectedIndex = InitialValueIndex.Value;
            }

            form.Controls.Add(newComboBox);

            if (0 == rowNumber)
            {
                newComboBox.Select();
            }
        }
    }
}
