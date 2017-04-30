using System.Windows.Forms;

namespace Prompt
{
    public interface IPromptItem
    {
        void Register(Form form, int rowNumber);
    }
}
