using System;
using System.Collections.Generic;
using System.Text;
using WSPI.ViewModel;

namespace WSPI.Infracture
{
    public class InstanceLacator
    {
        public MainViewModel Main { get; set; }

        public InstanceLacator() 
        {
            this.Main = new MainViewModel();
        }
    }
}
