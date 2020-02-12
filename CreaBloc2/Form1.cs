using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace CreaBloc2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //Trigger Boutton Insertion de ligne dans le dataGridView
            DataBloc.Rows.Add();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //Trigger Boutton Supprimer Ligne dans le dataGridView
            if (DataBloc.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection row = DataBloc.SelectedRows;

                DataBloc.Rows.RemoveAt(DataBloc.SelectedRows[0].Index);

            }
            else
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Erreur", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Trigger Button pour quitter
            if (MessageBox.Show("Voulez-vous vraiment quitter", " Creabloc ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Trigger boutton Annuler
            DataBloc.Rows.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Trigger Boutton Ouvrir Fichier
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Ouvre la selection de fichier
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Affiche la taille du fichier en mode debug (console)
            Console.WriteLine(result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBlocsDataSet.Composants' table. You can move, or remove it, as needed.
            this.composantsTableAdapter.Fill(this.dBBlocsDataSet.Composants);


        }

        private void DataBloc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (i < DataBloc.Rows.Count)
            {
                DataBloc.Rows[i].Cells[0].Value = i + 1;
                i++;
            }
        }

        private void DataBloc_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            i = 0;
            while (i < DataBloc.Rows.Count)
            {
                DataBloc.Rows[i].Cells[0].Value = i + 1;
                i++;
            }

        }
    }
}

