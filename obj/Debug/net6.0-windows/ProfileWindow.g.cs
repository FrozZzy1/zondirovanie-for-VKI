﻿#pragma checksum "..\..\..\ProfileWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F61DA772C97DCE4B48D3889A299A000CBDF3672C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GeophysicsApp;
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


namespace GeophysicsApp {
    
    
    /// <summary>
    /// ProfileWindow
    /// </summary>
    public partial class ProfileWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas picketsDiagram;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonBack;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridMeasurements;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonEditMeasurements;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDeleteMeasurements;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddMeasurements;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridPickets;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonEditPickets;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDeletePickets;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\ProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddPickets;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GeophysicsApp;component/profilewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ProfileWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.picketsDiagram = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.buttonBack = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\ProfileWindow.xaml"
            this.buttonBack.Click += new System.Windows.RoutedEventHandler(this.buttonBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gridMeasurements = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.buttonEditMeasurements = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.buttonDeleteMeasurements = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.buttonAddMeasurements = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.gridPickets = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.buttonEditPickets = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.buttonDeletePickets = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.buttonAddPickets = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

