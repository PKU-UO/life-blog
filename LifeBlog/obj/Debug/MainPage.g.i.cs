﻿#pragma checksum "D:\WorkSpaces\visual studio 2012\Projects\life-blog\LifeBlog\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CA4EDCD6071017D49535532CAB6C25D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18033
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace LifeBlog {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.StackPanel login;
        
        internal System.Windows.Controls.TextBox userName;
        
        internal System.Windows.Controls.PasswordBox password;
        
        internal System.Windows.Controls.TextBlock hind;
        
        internal System.Windows.Controls.Button LoginIn;
        
        internal System.Windows.Controls.TextBlock Forgetpass;
        
        internal System.Windows.Controls.TextBlock select_connection;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/LifeBlog;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.login = ((System.Windows.Controls.StackPanel)(this.FindName("login")));
            this.userName = ((System.Windows.Controls.TextBox)(this.FindName("userName")));
            this.password = ((System.Windows.Controls.PasswordBox)(this.FindName("password")));
            this.hind = ((System.Windows.Controls.TextBlock)(this.FindName("hind")));
            this.LoginIn = ((System.Windows.Controls.Button)(this.FindName("LoginIn")));
            this.Forgetpass = ((System.Windows.Controls.TextBlock)(this.FindName("Forgetpass")));
            this.select_connection = ((System.Windows.Controls.TextBlock)(this.FindName("select_connection")));
        }
    }
}

