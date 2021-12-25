using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BILAL_OIL_QUERY_CRYSTALREPORT_
{
    public partial class Form1 : Form
    {
        ReportDocument crypt = new ReportDocument();
        SqlConnection con = new SqlConnection("Data Source=51.89.37.225;Initial Catalog=BILAL_OIL;User ID=sa;Password=blue@1122");
        SqlDataAdapter sda;
                                                                                                                        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text=="View Full Report")
            {
            
            con.Open();
            sda = new SqlDataAdapter("select materials.material_id,materials.material_name,purchases_order.date,purchases_order.po_number,purchases_order.weight from materials inner join purchases_order on materials.material_id =purchases_order.material_id where date between '"+this.dateTimePicker1.Value.ToString("yyyyMMdd") + "'and '"+this.dateTimePicker2.Value.ToString("yyyyMMdd") + "'",con);

            DataSet1 ds = new DataSet1();
            sda.Fill(ds, "Materials_Detail");
            crypt.Load("CrystalReport1.rpt");
            con.Close();
            crypt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = crypt;

            }
            else
            { 
            con.Open();
            sda = new SqlDataAdapter("select materials.material_id, materials.material_name, purchases_order.date, purchases_order.po_number, purchases_order.weight from materials inner join purchases_order on materials.material_id = purchases_order.material_id where materials.material_name = '" + comboBox1.Text + "' and date between'" + this.dateTimePicker1.Value.ToString("yyyyMMdd") + "'and '" + this.dateTimePicker2.Value.ToString("yyyyMMdd") + "'", con);

            DataSet ds = new DataSet();
            sda.Fill(ds, "Materials_Detail");
            crypt.Load("CrystalReport1.rpt");
            crypt.SetDataSource(ds);
            con.Close();
            crystalReportViewer1.ReportSource = crypt;
            crystalReportViewer1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            sda = new SqlDataAdapter("select materials.material_id,materials.material_name,purchases_order.date,purchases_order.po_number,purchases_order.weight from materials inner join purchases_order on materials.material_id =purchases_order.material_id", con);

            DataSet ds = new DataSet();
            sda.Fill(ds, "Materials_Detail");
            crypt.Load("CrystalReport1.rpt");
            con.Close();
            crypt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = crypt;
        }
    }
}
