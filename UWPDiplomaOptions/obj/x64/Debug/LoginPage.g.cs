<<<<<<< HEAD
﻿#pragma checksum "C:\Users\Shane\Desktop\UWPDiplomaOptions-master\UWPDiplomaOptions\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F93F377FBFD0F2969A7519CBD78B177D"
=======
﻿#pragma checksum "C:\Users\Guanyi\Documents\Visual Studio 2015\Projects\UWPDiplomaOptions\UWPDiplomaOptions\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "000795C762F4F71809F3685ECD310E97"
>>>>>>> c9c33172a8f1f2297da6e3e0e17f1fa7c4916895
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
                    this.LoginProessRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 2:
                {
                    this.TitleBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.SubTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.StudentNumberBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.StudentNumberBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.PasswordBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.PasswordBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 8:
                {
                    this.RememberMe = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 9:
                {
                    this.LoginButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 20 "..\..\..\LoginPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.LoginButton).Click += this.LoginButton_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.NewStudentBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.RegisterButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 22 "..\..\..\LoginPage.xaml"
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

