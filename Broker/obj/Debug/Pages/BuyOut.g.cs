#pragma checksum "..\..\..\Pages\BuyOut.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "462EB8E7262B9A1F52E488D737346D30E9DF5D0E8386B5C7A36B39E801443A28"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Broker.Pages;
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


namespace Broker.Pages {
    
    
    /// <summary>
    /// BuyOut
    /// </summary>
    public partial class BuyOut : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Choose;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChoose;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Ordered;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbStonks;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtd;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxCount;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\BuyOut.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Order;
        
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
            System.Uri resourceLocater = new System.Uri("/Broker;component/pages/buyout.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\BuyOut.xaml"
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
            this.Choose = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.btnChoose = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Pages\BuyOut.xaml"
            this.btnChoose.Click += new System.Windows.RoutedEventHandler(this.btnChooseClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Ordered = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.cmbStonks = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tbxCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Order = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Pages\BuyOut.xaml"
            this.Order.Click += new System.Windows.RoutedEventHandler(this.Order_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

