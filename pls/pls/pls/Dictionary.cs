using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pls
{
    public partial class Dictionary : Form
    {
        public Dictionary()
        {
            InitializeComponent();
        }
        List<Themtu> Tudien = new List<Themtu>();


        //Tìm kiếm từ vựng khi nhấn nút Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> DictData = new Dictionary<string, string>();
            StreamReader textFile = new StreamReader("dictionary.txt");
            string readLine = null;
            string[] word = null;
            do
            {
                readLine = textFile.ReadLine();
                if (readLine != null)
                {
                    word = readLine.Split(':');
                    DictData.Add(word[0], word[1]);
                }
                else
                {
                    rtbnRearch.Text = "Từ không tồn tại trong dữ liệu của từ điển";
                }
                foreach (KeyValuePair<string, string> UserInput in DictData)
                {
                    if ((UserInput.Key).ToLower() == (txbSearch.Text).ToLower())
                    {
                        rtbnRearch.Text = UserInput.Value;
                    }
                }
            }
            while (readLine != null && word[0] != txbSearch.Text);
        }


        //Xác nhận muốn thoát khi nhấn nút Exit ở tab tìm kiếm
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
                ("Bạn có chắc muốn thoát không?", "", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }


        //Hiển thị từ điển được thêm lên listbox 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Themtu Dic = new Themtu();
            Dic.Anh = tbnEng.Text;
            Dic.Viet = tbnViet.Text;
            Tudien.Add(Dic);
            HienThiThemtudien();
        }
        private void HienThiThemtudien()
        {
            lstDic.Items.Clear();
            foreach (Themtu Dic in Tudien)
            {
                lstDic.Items.Add(Dic);
            }
        }


        //Thông báo lưu thành công, ngược lại sẽ báo lỗi
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + "//dictionary.txt";
                bool kq = FileLuuTudien.FileLuu(Tudien, path);
                if (kq == true)
                {
                    MessageBox.Show("Bạn đã lưu thành công !");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        //Xác nhận muốn thoát khi nhấn nút Exit ở tab thêm từ
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
               ("Bạn có chắc muốn thoát không?", "", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void rtbnRearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
