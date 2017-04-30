using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Prompt
{
    public sealed partial class PromptForm : Form
    {
        public PromptForm(string promptTitle,
                          ICollection<IPromptItem> promptFields)
        {
            if (null == promptFields || 0 == promptFields.Count)
            {
                throw new ArgumentNullException("promptFields", "Empty prompt fields");
            }

            InitializeComponent();

            if (!string.IsNullOrEmpty(promptTitle))
            {
                Text = promptTitle;
            }

            var rowCounter = 0;
            foreach (var promptItem in promptFields)
            {
                promptItem.Register(this, rowCounter++);
                Height += PromptItem.RowHeight;
            }
        }
    }
}
