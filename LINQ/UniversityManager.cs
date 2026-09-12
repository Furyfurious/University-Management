using System;
using System.Collections.Generic;
using System.Diagnostics; // added
using System.Linq;
using System.Text;

namespace LINQ
{
    internal class UniversityManager
    {
        
        private DataHandling Data = new DataHandling();
        private UniversityDisplay DisplayMenu;
        public UniversityManager()
        {
            DisplayMenu = new UniversityDisplay(Data);
        }

        public void Show()
        {
            DisplayMenu.Menu();
        }
    }
  
}
