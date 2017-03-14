using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google_API;


namespace AriesLifeManager
{
    public partial class Form1 : Form
    {
        GoogleContacts c;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvContacts.BeginUpdate();
            populatelvContacts();
            lvContacts.EndUpdate();

            c = new GoogleContacts();
            c.Connect();
            if (c.Messages.Count > 0)
                MessageBox.Show(c.Messages.ToString());

        }

        private void populatelvContacts()
        {
            lvContacts.Columns.Insert(0, "Name", 200);
            lvContacts.Columns.Insert(1, "e-mail", 200);
            lvContacts.Columns.Insert(2, "Phone", 100);
            lvContacts.Columns.Insert(3, "Birthday", 100);
            //lvContacts.BackColor = Color.PaleGreen;


            Relations rel = new Relations();
            var rrlist = rel.getRelations();
            foreach(Relation r in rrlist)
            {
                ListViewItem lvi = new ListViewItem(r.name);
                String[] subitems = new string[4];

                subitems[0] = (r.email != null) ? r.email : " ";
                subitems[1] = (r.phone != null) ? r.phone : " ";
                subitems[2] = (r.birthday != DateTime.MinValue) ? r.birthday.ToShortDateString() : " ";
                lvi.SubItems.AddRange(subitems);
                lvContacts.Items.Add(lvi);
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(c.getLastMessage());
        }
    }
}
