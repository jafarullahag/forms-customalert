using System;
using Custom.Popup.Common;
using Custom.Popup.Views.Alert;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Custom.Popup.ViewModel
{
    public class BaseviewModel: NotifyPropertyChanged
    {
        public BaseviewModel()
        {
        }

        private Page _page;
        public Page Page
        {
            get
            {
                return _page;
            }
        }

        VisualElement _visualElement;
        public VisualElement VisualElement
        {
            get
            {
                return _visualElement;
            }
            set
            {
                if (_visualElement != value && value != null)
                {
                    _visualElement = value;
                    var p = Page;

                    if (_visualElement is Page page)
                    {
                        _page = page;
                    }

                    if (_visualElement.BindingContext == null)
                    {
                        _visualElement.BindingContext = this;
                    }


                    OnPropertyChanged();
                }
            }
        }

        #region Alert
        AlertDialog alertDialog;
        public async void ShowOKAlert(string alertTitle, string alertMessage, string okButtonText = "Ok")
        {
            //if (okButtonText == "Ok")
                //okButtonText = Strings.Ok;


            alertDialog = new AlertDialog(alertTitle, alertMessage, okButtonText);
            alertDialog.AlertEvent += Popup_AlertEvent;
            await Page.Navigation.PushPopupAsync(alertDialog);
        }

        async void Popup_AlertEvent(AlertEventArgs _args)
        {
            alertDialog.AlertEvent -= Popup_AlertEvent;
            if (!_args.IsCancel)
            {

            }
            await Page.Navigation.PopPopupAsync();
        }

        public async void ShowConfirmationAlert(string alertTitle, string alertMessage, string cancelButtonText = "Cancel", string confirmButtonText = "Confirm")
        {
            alertDialog = new AlertDialog(alertTitle, alertMessage, cancelButtonText, confirmButtonText);
            alertDialog.AlertEvent += Popup_AlertConfirmationEvent;
            await Page.Navigation.PushPopupAsync(alertDialog);
        }

        async void Popup_AlertConfirmationEvent(AlertEventArgs _args)
        {
            alertDialog.AlertEvent -= Popup_AlertConfirmationEvent;
            if (!_args.IsCancel)
            {
                ConfrimationAlert_Result(_args.IsCancel);
            }
            await Page.Navigation.PopPopupAsync();
        }

        public virtual void ConfrimationAlert_Result(bool IsCancel)
        {

        }


        #endregion
    }
}
