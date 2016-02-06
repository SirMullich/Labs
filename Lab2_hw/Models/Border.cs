using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_hw.Models
{
    [Serializable]
    public class Border : Drawer
    {
        public Border()
        {
            color = ConsoleColor.Blue;
            sign = '*';
            for (int i = 0; i < 49; ++i)
            {
                body.Add(new Point { x = 48, y = i});
                body.Add(new Point { x = i, y = 48});
            }
        }
    }
}
