﻿#pragma checksum "..\..\..\EditBillWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0A99B83580629CD0B7CD04D81E2B34241A367DF9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace WPF {
    
    
    /// <summary>
    /// EditBillWindow
    /// </summary>
    public partial class EditBillWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRoom;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MonthYearTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ElectricityOldTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ElectricityNewTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WaterOldTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WaterNewTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ElectricityRateTextBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\EditBillWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WaterRateTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF;component/editbillwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditBillWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbRoom = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.MonthYearTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ElectricityOldTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ElectricityNewTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.WaterOldTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.WaterNewTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ElectricityRateTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.WaterRateTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 62 "..\..\..\EditBillWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateBillButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

