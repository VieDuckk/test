using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTX2
{
    public class NhanVien
    {
        public string hoten { get; set; }
        public string loainv { get; set; }
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public double sotienbanhang { get; set; }
     
        public double tienhoahong
        {
            get
            {
                if (sotienbanhang < 1000)
                {
                    return 0;
                }
                else if (sotienbanhang >= 1000 && sotienbanhang <= 5000)
                {
                    return sotienbanhang * 0.1;
                }
                else
                {
                    return sotienbanhang * 0.2;
                }

            }
            

        }
    }
}
