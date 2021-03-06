﻿using Agenda.CustomRenderer;
using Agenda.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseEntry), typeof(BaseEntryRenderer))]
namespace Agenda.iOS
{
    public class BaseEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            BaseEntry base_entry = (BaseEntry)this.Element;

            base.OnElementChanged(e);

            if (Control != null && base_entry != null)
            {
                SetReturnType(base_entry);

                Control.ShouldReturn += (UITextField tf) => {
                    base_entry.InvokeCompleted();
                    return true;
                };
            }
        }

        private void SetReturnType(BaseEntry entry)
        {
            ReturnType type = entry.ReturnType;

            switch (type)
            {
                case ReturnType.Go:
                    Control.ReturnKeyType = UIReturnKeyType.Go;
                    break;
                case ReturnType.Next:
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                    break;
                case ReturnType.Send:
                    Control.ReturnKeyType = UIReturnKeyType.Send;
                    break;
                case ReturnType.Search:
                    Control.ReturnKeyType = UIReturnKeyType.Search;
                    break;
                case ReturnType.Done:
                    Control.ReturnKeyType = UIReturnKeyType.Done;
                    break;
                default:
                    Control.ReturnKeyType = UIReturnKeyType.Default;
                    break;

            }
        }
    }
}