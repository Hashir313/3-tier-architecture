using BuisnessLogicLayer;
using PropsLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tier3Architecture
{
    public partial class Form1 : Form
    {
        int rollNo, semester;
        String name, program , message;
        StudentProps studentProps = new StudentProps();
        StudentBLL studentBLL = new StudentBLL();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void clearTextFields()
        {
            txtName.Clear();
            txtProgram.Clear();
            txtRollNo.Clear();
            txtSemester.Clear();
        }

        private void btnViewByID_Click(object sender, EventArgs e)
        {
            rollNo = Convert.ToInt32(txtRollNo.Text);
            studentProps.StudentRollNo = rollNo;
            DataTable searchRollNo = new DataTable();
            searchRollNo = studentBLL.searchStudentsByRollNo(studentProps);
            dgvStudentInfo.DataSource = searchRollNo;
            clearTextFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            rollNo = Convert.ToInt32(txtRollNo.Text);
            semester = Convert.ToInt32(txtSemester.Text);
            name = txtName.Text;
            program = txtProgram.Text;

            studentProps.StudentRollNo = rollNo;
            studentProps.StudentSemester = semester;
            studentProps.StudentProgram = program;
            studentProps.StudentName = name;
            message = studentBLL.updateStudentBLL(studentProps);
            MessageBox.Show(message);
            clearTextFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            rollNo = Convert.ToInt32(txtRollNo.Text);
            studentProps.StudentRollNo = rollNo;
            message = studentBLL.deleteStudentBLL(studentProps);
            MessageBox.Show(message);
            clearTextFields();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataTable searchAll = new DataTable();
            searchAll = studentBLL.searchAllStudents();
            dgvStudentInfo.DataSource = searchAll;
            clearTextFields();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            rollNo = Convert.ToInt32(txtRollNo.Text);
            semester = Convert.ToInt32(txtSemester.Text);
            name = txtName.Text;
            program = txtProgram.Text;

            studentProps.StudentRollNo = rollNo;
            studentProps.StudentSemester = semester;
            studentProps.StudentProgram = program;
            studentProps.StudentName = name;
            message = studentBLL.insertStudentBLL(studentProps);
            MessageBox.Show(message);
            clearTextFields();
        }
    }
}
