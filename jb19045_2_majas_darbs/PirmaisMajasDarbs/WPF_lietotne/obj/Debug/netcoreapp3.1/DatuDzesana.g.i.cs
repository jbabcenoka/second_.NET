﻿#pragma checksum "..\..\..\DatuDzesana.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1B8ACA93E3DCEE29400BC39715ADB930408E329E"
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
using System.Windows.Forms.Integration;
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
using WPF_lietotne;


namespace WPF_lietotne {
    
    
    /// <summary>
    /// DatuDzesana
    /// </summary>
    public partial class DatuDzesana : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\DatuDzesana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pasutitaji;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\DatuDzesana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Darbinieki;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\DatuDzesana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Produkti;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\DatuDzesana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IzvelnesTeksts;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\DatuDzesana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboIzvelne;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\DatuDzesana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dzest;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF_lietotne;V1.0.0.0;component/datudzesana.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DatuDzesana.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Pasutitaji = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\DatuDzesana.xaml"
            this.Pasutitaji.Click += new System.Windows.RoutedEventHandler(this.Pasutitaji_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Darbinieki = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\DatuDzesana.xaml"
            this.Darbinieki.Click += new System.Windows.RoutedEventHandler(this.Darbinieki_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Produkti = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\DatuDzesana.xaml"
            this.Produkti.Click += new System.Windows.RoutedEventHandler(this.Produkti_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.IzvelnesTeksts = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cboIzvelne = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Dzest = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\DatuDzesana.xaml"
            this.Dzest.Click += new System.Windows.RoutedEventHandler(this.Dzest_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

