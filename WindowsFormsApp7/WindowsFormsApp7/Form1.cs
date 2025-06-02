using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class 职员信息登记: Form
    {
        public 职员信息登记()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem myLVI = lv1.Items.Add((lv1.Items.Count+1).ToString());
            myLVI.SubItems.Add(tbName.Text);
            myLVI.SubItems.Add(cbGender.Text);
            myLVI.SubItems.Add(tbTel.Text);
            myLVI.SubItems.Add(tbDepartment.Text);
            myLVI.SubItems.Add(dTPJoinTime.Value.ToString("yyyy年MM月dd日"));
            tbName.Clear();
            tbDepartment.Clear();
            cbGender.Text = "";
            tbTel.Clear();
            dTPJoinTime.Value = dTPJoinTime.MaxDate;
        }

        private void 职员信息登记_Load(object sender, EventArgs e)
        {
            dTPJoinTime.MaxDate = DateTime.Now;
            dTPJoinTime.Value = dTPJoinTime.MaxDate;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile(@"C:\Users\DELL\Desktop\新建文件夹\OIP-c.jpg");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                lv1.SelectedItems[0].SubItems[1].Text = tbName.Text;
                lv1.SelectedItems[0].SubItems[2].Text = cbGender.Text;
                lv1.SelectedItems[0].SubItems[3].Text = tbTel.Text;
                lv1.SelectedItems[0].SubItems[4].Text = tbDepartment.Text;
                lv1.SelectedItems[0].SubItems[5].Text = dTPJoinTime.Value.ToString("yyyy年MM月dd日");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                lv1.SelectedItems[0].Remove();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lv1.Items.Clear();
        }
        string[] path = System.IO.Directory.GetFiles(@"C:\Users\DELL\Desktop\新建文件夹\");
        Random r = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(path[r.Next(0,path.Length)]);
            int mum = 0;
            if (tbName.Text!= "") mum++;
            if (cbGender.Text != "") mum++;
            if (tbTel.Text != "") mum++;
            if (tbDepartment.Text != "") mum++;
            if (dTPJoinTime.Value!=dTPJoinTime.MaxDate) mum++;
            progressBar1.Value = mum;

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ListViewItem checkItem = lv1.FindItemWithText(tbCheck.Text);
            if (checkItem != null)
            {
                this.lv1.TopItem = checkItem;
                checkItem.ForeColor = Color.Red;
            }
            else
                MessageBox.Show("未找到该姓名");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
