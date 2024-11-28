using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTX2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<NhanVien> dsNhanVien = new List<NhanVien>();

        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            if (iskiemtra())
            {
                NhanVien nvmoi = new NhanVien();
                nvmoi.hoten = txthoten.Text;
                nvmoi.loainv = cboloainv.Text;
                nvmoi.ngaysinh = Convert.ToDateTime(dpngaysinh.SelectedDate);
                nvmoi.sotienbanhang = double.Parse(txtsotienbanhang.Text);
                if(radNam.IsChecked == true) 
                {
                    nvmoi.gioitinh = "Nam";
                }
                else
                {
                    nvmoi.gioitinh = "Nữ";
                }
                dsNhanVien.Add(nvmoi);
                dtgnhanvien.ItemsSource = null;
                dtgnhanvien.ItemsSource = dsNhanVien; 
            }
        }


        private void btnwin2_Click(object sender, RoutedEventArgs e)
        {

            var nhanVienChon = dtgnhanvien.SelectedItems.Cast<NhanVien>().ToList();


            if (nhanVienChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhân viên!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            Window2 win2 = new Window2(nhanVienChon);
            win2.Show();
            ////TIM TIEN HOA HONG CAO NHAT
            //double tienhoahongmax = dsNhanVien[0].tienhoahong;
            //for (int i = 1; i < dsNhanVien.Count; i++)
            //{
            //    if (dsNhanVien[i].tienhoahong > tienhoahongmax)
            //        tienhoahongmax = dsNhanVien[i].tienhoahong;
            //}
            //// tao danh sach chua nv co tien hoa hong = tienhoahongmax
            //List<NhanVien> dstienhoahongmax = new List<NhanVien>();
            //foreach (var item in dsNhanVien)
            //{
            //    if (item.tienhoahong == tienhoahongmax)
            //    {
            //        dstienhoahongmax.Add(item);
            //    }
            //}
            //Window2 myWindow = new Window2();
            //myWindow.dtgtienhoahongmax.ItemsSource = dstienhoahongmax;
            //myWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpngaysinh.SelectedDate = DateTime.Now;
        }
        private bool iskiemtra()
        {
            if (txthoten.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nv","Lỗi nhập dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                txthoten.Focus();
                return false;
            }
            if (txtsotienbanhang.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền bán hàng", "Lỗi nhập dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                txtsotienbanhang.Focus();
                return false;
            }
            //so tien là số thực>0
            try
            {
                double.Parse(txtsotienbanhang.Text);
            }catch(Exception) 
            {
                MessageBox.Show("Hệ số lương phải là số thực", "Lỗi nhập dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                txtsotienbanhang.SelectAll();
                txtsotienbanhang.Focus();
                return false;
            }
            //tuổi >18<60
            int tuoi = DateTime.Now.Year - dpngaysinh.SelectedDate.Value.Year;
            if (tuoi < 18)
            {
                MessageBox.Show("Tuổi phải >=18 và <=60", "Lỗi nhập dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if(tuoi >60)
            {
                MessageBox.Show("Tuổi phải >=18 và <=60", "Lỗi nhập dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
            
    }
}