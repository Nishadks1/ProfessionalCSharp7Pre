using Formula1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TreeViewSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            TreeViewNode parentNode1 = new TreeViewNode()
            {
                Data = "one",
                IsExpanded = true
            };
            TreeViewNode childNode1 = new TreeViewNode
            {
                Data = "two",
                IsExpanded = true,
                ParentNode = parentNode1,
                HasUnrealizedItems = true
            };
            parentNode1.Add(childNode1);
            treeView.RootNode.Add(parentNode1);
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            // Todo: check what can be done with treeView.ListControl - a flat list of all the items attached
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            Formula1Services services = (Application.Current as App).Container.GetService<Formula1Services>();
            IEnumerable<int> years = services.GetYears();
        }
    }
}
