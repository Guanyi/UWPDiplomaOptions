﻿#pragma checksum "C:\Users\chaos\Desktop\COMP4976\UWPDiplomaOptions\UWPDiplomaOptions\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F00CA888AF4133586BD7EA99F260B26B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWPDiplomaOptions
{
    partial class LoginPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.TitleBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.SubTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.StudentNumberBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.StudentNumberBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.PasswordBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.PasswordBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7:
                {
                    this.RememberMe = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 8:
                {
                    this.LoginButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 19 "..\..\..\LoginPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.LoginButton).Click += this.LoginButton_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.NewStudentBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.RegisterButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 21 "..\..\..\LoginPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.RegisterButton).Click += this.RegisterButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

