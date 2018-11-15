using System;
namespace Custom.Popup.ViewModel
{
    public class AlertViewModel : BaseviewModel
    {
        private string alertTitle;
        public string AlertTitle
        {
            get { return alertTitle; }
            set { alertTitle = value; OnPropertyChanged(); }
        }

        private string alertMessage;
        public string AlertMessage
        {
            get { return alertMessage; }
            set { alertMessage = value; OnPropertyChanged(); }
        }

        private string okButtonText;
        public string OkButtonText
        {
            get { return okButtonText; }
            set { okButtonText = value; OnPropertyChanged(); }
        }

        private string confirmationYesButtonText;
        public string ConfirmationYesButtonText
        {
            get { return confirmationYesButtonText; }
            set { confirmationYesButtonText = value; OnPropertyChanged(); }
        }

        private string confirmationNoButtonText;
        public string ConfirmationNoButtonText
        {
            get { return confirmationNoButtonText; }
            set { confirmationNoButtonText = value; OnPropertyChanged(); }
        }

        public AlertViewModel()
        {
        }
    }
}
