﻿#pragma checksum "Views\Train.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F25E5FE54CDC4EA09BB2F7DE65D5788B8614851C83E0B9D0C776DCEC64E77FFB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KeyboardTrainer.Views;
using MyApp.Tools;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace KeyboardTrainer.Views {
    
    
    /// <summary>
    /// Train
    /// </summary>
    public partial class Train : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 29 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label btn_back;
        
        #line default
        #line hidden
        
        
        #line 30 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label btn_maximize;
        
        #line default
        #line hidden
        
        
        #line 31 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label btn_normalize;
        
        #line default
        #line hidden
        
        
        #line 34 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textblockText;
        
        #line default
        #line hidden
        
        
        #line 35 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textInfo;
        
        #line default
        #line hidden
        
        
        #line 36 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbl_retry;
        
        #line default
        #line hidden
        
        
        #line 39 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_left;
        
        #line default
        #line hidden
        
        
        #line 40 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_mistakes;
        
        #line default
        #line hidden
        
        
        #line 41 "Views\Train.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_time;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KeyboardTrainer;component/views/train.xaml", System.UriKind.Relative);
            
            #line 1 "Views\Train.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btn_back = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btn_maximize = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btn_normalize = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.textblockText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.textInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.lbl_retry = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.lbl_left = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lbl_mistakes = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lbl_time = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
