using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppStudio.Uwp.Navigation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace TechNewsHub.Navigation
{
    public class AppNavigation
    {
        private NavigationNode _active;

        static AppNavigation()
        {

        }

        public NavigationNode Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != null)
                {
                    _active.IsSelected = false;
                }
                _active = value;
                if (_active != null)
                {
                    _active.IsSelected = true;
                }
            }
        }


        public ObservableCollection<NavigationNode> Nodes { get; private set; }

        public void LoadNavigation()
        {
            Nodes = new ObservableCollection<NavigationNode>();
		    var resourceLoader = new ResourceLoader();
			AddNode(Nodes, "Home", "\ue10f", string.Empty, "HomePage", true, @"Tech News Hub");
			AddNode(Nodes, "ZDNET", "\ue12a", string.Empty, "ZDNETListPage", true);			
			AddNode(Nodes, "The Verge", "\ue12a", string.Empty, "TheVergeListPage", true);			
			AddNode(Nodes, "Tech News", "\ue12a", string.Empty, "TechNewsListPage", true);			
			AddNode(Nodes, resourceLoader.GetString("NavigationPanePrivacy"), "\ue1f7", string.Empty, string.Empty, true, string.Empty, "http://appstudio.windows.com/home/appprivacyterms");            
        }

		private void AddNode(ObservableCollection<NavigationNode> nodes, string label, string fontIcon, string image, string pageName, bool isVisible = true, string title = null, string deepLinkUrl = null, bool isSelected = false)
        {
            if (nodes != null && isVisible)
            {
                var node = new ItemNavigationNode
                {
                    Title = title,
                    Label = label,
                    FontIcon = fontIcon,
                    Image = image,
                    IsSelected = isSelected,
                    IsVisible = isVisible,
                    NavigationInfo = NavigationInfo.FromPage(pageName)
                };
                if (!string.IsNullOrEmpty(deepLinkUrl))
                {
                    node.NavigationInfo = new NavigationInfo()
                    {
                        NavigationType = NavigationType.DeepLink,
                        TargetUri = new Uri(deepLinkUrl, UriKind.Absolute)
                    };
                }
                nodes.Add(node);
            }            
        }

        public NavigationNode FindPage(Type pageType)
        {
            return GetAllItemNodes(Nodes).FirstOrDefault(n => n.NavigationInfo.NavigationType == NavigationType.Page && n.NavigationInfo.TargetPage == pageType.Name);
        }

        private IEnumerable<ItemNavigationNode> GetAllItemNodes(IEnumerable<NavigationNode> nodes)
        {
            foreach (var node in nodes)
            {
                if (node is ItemNavigationNode)
                {
                    yield return node as ItemNavigationNode;
                }
                else if(node is GroupNavigationNode)
                {
                    var gNode = node as GroupNavigationNode;

                    foreach (var innerNode in GetAllItemNodes(gNode.Nodes))
                    {
                        yield return innerNode;
                    }
                }
            }
        }
    }
}
