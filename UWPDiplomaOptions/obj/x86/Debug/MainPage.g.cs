﻿#pragma checksum "C:\Users\Guanyi\Documents\Visual Studio 2015\Projects\UWPDiplomaOptions\UWPDiplomaOptions\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF55265CB9F81447EA336C53CB45EEC4"
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
    partial class MainPage : 
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
                    this.MainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 2:
                {
                    this.Footer = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.HomeButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 12 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HomeButton).Click += this.HomeButton_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 13 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.BackButton_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.ForwardButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ForwardButton).Click += this.ForwardButton_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.LogOffButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 15 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.LogOffButton).Click += this.LogOffButton_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.ManageOptionButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 16 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ManageOptionButton).Click += this.ManageOptionButton_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.ManageYearTermButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ManageYearTermButton).Click += this.ManageYearTermButton_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.ManageUserRoleButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 18 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ManageUserRoleButton).Click += this.ManageUserRoleButton_Click;
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

