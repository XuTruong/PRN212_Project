﻿#pragma checksum "..\..\..\MonthlyBillManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89106854AFE42182AE32338050613EC008C6F9BE"
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
    /// MonthlyBillManager
    /// </summary>
    public partial class MonthlyBillManager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\MonthlyBillManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbMonth;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MonthlyBillManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbYear;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MonthlyBillManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgMonthlyBills;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\MonthlyBillManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateBill;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\MonthlyBillManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditBill;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF;component/monthlybillmanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MonthlyBillManager.xaml"
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
            this.cbMonth = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cbYear = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 33 "..\..\..\MonthlyBillManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnFilterByMonth_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dgMonthlyBills = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btnCreateBill = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\MonthlyBillManager.xaml"
            this.btnCreateBill.Click += new System.Windows.RoutedEventHandler(this.btnCreateBill_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEditBill = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\MonthlyBillManager.xaml"
            this.btnEditBill.Click += new System.Windows.RoutedEventHandler(this.btnEditBill_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

