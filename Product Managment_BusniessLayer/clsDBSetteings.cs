using Products_Managment_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Managment_BusniessLayer
{
    public  static class clsDBSetteings
    {

        public static bool RestoreDatabase(string backupFilePath)
        {
            return clsDataAccessSettings.RestoreDatabase(backupFilePath);
        }
    }
}
