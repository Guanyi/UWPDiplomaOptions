﻿#pragma checksum "C:\Users\chaos\Desktop\COMP4976\UWPDiplomaOptions\UWPDiplomaOptions\ManageChoicePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45ED7D781BD34264240FFCFEB01F5DA9"
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
    partial class ManageChoicePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_FrameworkElement_Tag(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Tag = value;
            }
        };

        private class ManageChoicePage_obj14_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IManageChoicePage_Bindings
        {
            private global::UWPDiplomaOptions.Models.Choice dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj15;
            private global::Windows.UI.Xaml.Controls.TextBlock obj16;
            private global::Windows.UI.Xaml.Controls.TextBlock obj17;
            private global::Windows.UI.Xaml.Controls.TextBlock obj18;
            private global::Windows.UI.Xaml.Controls.TextBlock obj19;
            private global::Windows.UI.Xaml.Controls.TextBlock obj20;
            private global::Windows.UI.Xaml.Controls.TextBlock obj21;
            private global::Windows.UI.Xaml.Controls.TextBlock obj22;
            private global::Windows.UI.Xaml.Controls.TextBlock obj23;
            private global::Windows.UI.Xaml.Controls.TextBlock obj24;
            private global::Windows.UI.Xaml.Controls.TextBlock obj25;
            private global::Windows.UI.Xaml.Controls.Button obj26;
            private global::Windows.UI.Xaml.Controls.Button obj27;

            public ManageChoicePage_obj14_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 15:
                        this.obj15 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 16:
                        this.obj16 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 17:
                        this.obj17 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 18:
                        this.obj18 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 19:
                        this.obj19 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 20:
                        this.obj20 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 21:
                        this.obj21 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 22:
                        this.obj22 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 23:
                        this.obj23 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 24:
                        this.obj24 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 25:
                        this.obj25 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 26:
                        this.obj26 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 27:
                        this.obj27 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::UWPDiplomaOptions.Models.Choice data = args.NewValue as global::UWPDiplomaOptions.Models.Choice;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::UWPDiplomaOptions.Models.Choice was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::UWPDiplomaOptions.Models.Choice);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Grid)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::UWPDiplomaOptions.Models.Choice) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IManageChoicePage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // ManageChoicePage_obj14_Bindings

            public void SetDataRoot(global::UWPDiplomaOptions.Models.Choice newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UWPDiplomaOptions.Models.Choice obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ChoiceId(obj.ChoiceId, phase);
                        this.Update_StudentId(obj.StudentId, phase);
                        this.Update_StudentFirstName(obj.StudentFirstName, phase);
                        this.Update_StudentLastName(obj.StudentLastName, phase);
                        this.Update_FirstChoiceOptionTitle(obj.FirstChoiceOptionTitle, phase);
                        this.Update_SecondChoiceOptionTitle(obj.SecondChoiceOptionTitle, phase);
                        this.Update_ThirdChoiceOptionTitle(obj.ThirdChoiceOptionTitle, phase);
                        this.Update_FourthChoiceOptionTitle(obj.FourthChoiceOptionTitle, phase);
                        this.Update_Year(obj.Year, phase);
                        this.Update_Term(obj.Term, phase);
                        this.Update_SelectionDate(obj.SelectionDate, phase);
                    }
                }
            }
            private void Update_ChoiceId(global::System.Int32 obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj15, obj.ToString(), null);
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_Tag(this.obj26, obj, null);
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_Tag(this.obj27, obj, null);
                }
            }
            private void Update_StudentId(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj16, obj, null);
                }
            }
            private void Update_StudentFirstName(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj17, obj, null);
                }
            }
            private void Update_StudentLastName(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj18, obj, null);
                }
            }
            private void Update_FirstChoiceOptionTitle(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj19, obj, null);
                }
            }
            private void Update_SecondChoiceOptionTitle(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj20, obj, null);
                }
            }
            private void Update_ThirdChoiceOptionTitle(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj21, obj, null);
                }
            }
            private void Update_FourthChoiceOptionTitle(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj22, obj, null);
                }
            }
            private void Update_Year(global::System.Int32 obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj23, obj.ToString(), null);
                }
            }
            private void Update_Term(global::System.Int32 obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj24, obj.ToString(), null);
                }
            }
            private void Update_SelectionDate(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj25, obj, null);
                }
            }
        }

        private class ManageChoicePage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IManageChoicePage_Bindings
        {
            private global::UWPDiplomaOptions.ManageChoicePage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj13;

            public ManageChoicePage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 13:
                        this.obj13 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IManageChoicePage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // ManageChoicePage_obj1_Bindings

            public void SetDataRoot(global::UWPDiplomaOptions.ManageChoicePage newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UWPDiplomaOptions.ManageChoicePage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Choices(obj.Choices, phase);
                    }
                }
            }
            private void Update_Choices(global::System.Collections.ObjectModel.ObservableCollection<global::UWPDiplomaOptions.Models.Choice> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj13, obj, null);
                }
            }
        }
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
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 8 "..\..\..\ManageChoicePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                    #line default
                }
                break;
            case 2:
                {
                    this.txtId = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3:
                {
                    this.txtStudentId = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.txtFName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.txtLName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.cbFirstChoice = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7:
                {
                    this.cbSecondChoice = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 8:
                {
                    this.cbThirdChoice = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 9:
                {
                    this.cbFourthChoice = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 10:
                {
                    this.cbYear = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 11:
                {
                    this.cbTerm = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 12:
                {
                    this.SaveButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 97 "..\..\..\ManageChoicePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveButton).Click += this.EditChoice_Click;
                    #line default
                }
                break;
            case 26:
                {
                    global::Windows.UI.Xaml.Controls.Button element26 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 79 "..\..\..\ManageChoicePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element26).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 27:
                {
                    global::Windows.UI.Xaml.Controls.Button element27 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 80 "..\..\..\ManageChoicePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element27).Click += this.Button_Click;
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
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ManageChoicePage_obj1_Bindings bindings = new ManageChoicePage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 14:
                {
                    global::Windows.UI.Xaml.Controls.Grid element14 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    ManageChoicePage_obj14_Bindings bindings = new ManageChoicePage_obj14_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::UWPDiplomaOptions.Models.Choice) element14.DataContext);
                    element14.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element14, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

