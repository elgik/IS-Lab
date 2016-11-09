using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using IS_Lab.Domain;

namespace IS_Lab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            using (Context context = new Context())
            {
                if (!context.Database.Exists())
                    context.Database.Create();
            }
        }
    }
}
