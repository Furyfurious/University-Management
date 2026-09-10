using System;
using System.Collections.Generic;
using System.Diagnostics; // added
using System.Linq;
using System.Text;

namespace LINQ
{
    internal class UniversityManager
    {
        
        private DataHandling Data;
        private UniversityDisplay DisplayMenu;
        public UniversityManager()
        {
            Data = new DataHandling();
            DisplayMenu = new UniversityDisplay(Data);
        }

        public void Show()
        {
            DisplayMenu.Menu();
        }
    }
  
}
