﻿#pragma checksum "C:\Users\Dell\source\repos\BookTimer\BookTimer\Views\AddBookPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D6D9CFA3A72C19EBD3A1C32C7D9EC113"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookTimer.Views
{
    partial class AddBookPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\AddBookPage.xaml line 56
                {
                    this.yourLibraryButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.yourLibraryButton).Click += this.YourLibraryButton_Click;
                }
                break;
            case 3: // Views\AddBookPage.xaml line 43
                {
                    this.searchButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.searchButton).Click += this.SearchButton_Click;
                }
                break;
            case 4: // Views\AddBookPage.xaml line 52
                {
                    this.add = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.add).Click += this.Add_Click;
                }
                break;
            case 5: // Views\AddBookPage.xaml line 53
                {
                    this.show = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.show).Click += this.Show_Click;
                }
                break;
            case 6: // Views\AddBookPage.xaml line 40
                {
                    this.tbTitle = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Views\AddBookPage.xaml line 37
                {
                    this.tbAuthor = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

