using KTMPOS.Common.Model.Common;

using Message = KTMPOS.Common.Constants.Message;

namespace KTMPOS.Desktop.Utilities
{
    public static class DialogMessage
    {
        public static DialogResult ConfirmAlert(string message = Message.ConfirmDeleteMessage, string caption = Message.ConfirmDelete)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void SuccessAlert(string message)
        {
            MessageBox.Show(message, Message.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void FailedAlert(string error)
        {
            MessageBox.Show(error, Message.Failed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void FailedAlert(Output result)
        {
            if(result.ValidationResult is not null)
            {
                var errorList = result
                                .ValidationResult
                                .Errors
                                .Select(e => e.ErrorMessage)
                                .ToList();
                string errors = String.Join(Environment.NewLine, errorList);
                MessageBox.Show(errors, Message.Failed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(result.Error, Message.Failed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}