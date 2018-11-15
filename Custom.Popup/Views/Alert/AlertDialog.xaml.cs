using System;
using System.Collections.Generic;
using Custom.Popup.ViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Custom.Popup.Views.Alert
{
    public class AlertEventArgs : EventArgs
    {
        public bool IsCancel { get; set; }
    }

    public delegate void AlertEventDelegate(AlertEventArgs _args);
    public partial class AlertDialog : PopupPage
    {
        private readonly AlertViewModel viewModel;
        public event AlertEventDelegate AlertEvent;
        public AlertDialog(string alertTitle, string alertMessage, string alertOkButtonText)
        {
            InitializeComponent();
            CloseWhenBackgroundIsClicked = false;
            ConfirmationAlert.IsVisible = false;
            OkAlert.IsVisible = true;

            viewModel = new AlertViewModel()
            {
                VisualElement = this,
                AlertTitle = alertTitle,
                AlertMessage = alertMessage,
                OkButtonText = alertOkButtonText
            };
        }

        public AlertDialog(string alertTitle, string alertMessage, string confirmationYesButtonText, string confirmationNoButtonText)
        {
            InitializeComponent();

            ConfirmationAlert.IsVisible = true;
            OkAlert.IsVisible = false;

            viewModel = new AlertViewModel()
            {
                VisualElement = this,
                AlertTitle = alertTitle,
                AlertMessage = alertMessage,
                ConfirmationNoButtonText = confirmationYesButtonText,
                ConfirmationYesButtonText = confirmationNoButtonText
            };
        }

        void Confirm_Clicked(object sender, EventArgs e)
        {
            var args = new AlertEventArgs
            {
                IsCancel = false
            };
            AlertEvent(args);
        }

        void Cancel_Clicked(object sender, EventArgs e)
        {
            var args = new AlertEventArgs
            {
                IsCancel = true
            };
            AlertEvent(args);
        }
    }
}
