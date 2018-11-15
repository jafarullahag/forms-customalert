using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Custom.Popup.ViewModel
{
    public class MainPageViewModel : BaseviewModel
    {
        public MainPageViewModel()
        {
        }

        Command okCommand;
        public Command OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new Command(() => ShowInformationAlert()));
            }
        }

        private void ShowInformationAlert()
        {
            ShowOKAlert("Attention", "This is an information alert!");
        }

        Command confirmCommand;
        public Command ConfirmCommand
        {
            get
            {
                return confirmCommand ?? (confirmCommand = new Command(() => ShowConfirmationAlert()));
            }
        }

        private void ShowConfirmationAlert()
        {
            ShowConfirmationAlert("Attention", "This is a confirmation alert. Do you want to proceed?");
        }

        public override void ConfrimationAlert_Result(bool IsCancel)
        {
            base.ConfrimationAlert_Result(IsCancel);
        }

    }
}
