using MagicAccount.Pages;
using MagicIoC;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MagicAccount.PageModels.Base
{
    public class PageModelLocator
    {
        static MagicIoCContainer Container;
        static Dictionary<Type, Type> LookupTable;

        static PageModelLocator()
        {
            Container = new MagicIoCContainer();
            LookupTable = new Dictionary<Type, Type>();

            //Register Page and PageModels
            Register<DashBoardPageModel, DashBoardPage>();


            //Register Services as singletons



        }

        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            LookupTable.Add(typeof(TPageModel), typeof(TPage));
            Container.Register<TPageModel>();
        }

        public static T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        public static Page CreatePage(Type pagemodeltype)
        {
            var pagetype = LookupTable[pagemodeltype];
            var page = (Page)Activator.CreateInstance(pagetype);
            var pagemodel = Container.Resolve(pagemodeltype);
            page.BindingContext = pagemodel;
            return page;
        }
    }
}
