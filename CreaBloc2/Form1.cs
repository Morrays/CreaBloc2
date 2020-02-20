using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CreaBloc2
{
	public partial class Form1 : Form
	{
		public string language = Properties.Settings.Default.langue;   //Public String language to read the saved language settings
		public Form1()
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(language); //Launch the Form with the default/selected language
			InitializeComponent();
		}
		
		public int i = 0;

		//Trigger Boutton Insertion de ligne dans le dataGridView
		private void button1_Click(object sender, EventArgs e)
		{
			DataBloc.Rows.Add();
		}

		//Trigger Boutton Supprimer Ligne dans le dataGridView
		private void button2_Click_1(object sender, EventArgs e)
		{

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

		//Trigger Button pour quitter
		private void button5_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Voulez-vous vraiment quitter", " Creabloc ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				string dossier = "TempBloc";
				string fullPath = path + @"\" + dossier;
				File.Delete(fullPath + @"\newBloc.txt");
				Application.Exit();
			}
		}

		//Trigger boutton Annuler
		private void button4_Click(object sender, EventArgs e)
		{

			DataBloc.Rows.Clear();
		}

		//Trigger Boutton Ouvrir Fichier
		private void button6_Click(object sender, EventArgs e)
		{

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
			Console.WriteLine(size); //Affiche la taille du fichier en mode debug (console)
			Console.WriteLine(result);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'dBBlocsDataSet.elemBloc' table. You can move, or remove it, as needed.
			this.elemBlocTableAdapter.Fill(this.dBBlocsDataSet.elemBloc);
			// TODO: This line of code loads data into the 'dBBlocsDataSet.Composants' table. You can move, or remove it, as needed.
			this.composantsTableAdapter.Fill(this.dBBlocsDataSet.Composants);

			//Crée un fichier txt

			Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TempBloc"));
			

			//Emplacement du fichier temporaire
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string dossier = "TempBloc";
			string fullPath = path + @"\" + dossier;
			string nomFichier = fullPath + @"\newBloc.xrb";



			//Ecrit dans le fichier les lignes qui ne changent pas dans tous les blocs
			try
			{
				if (File.Exists(nomFichier))
				{
					File.Delete(nomFichier);
				}

				using (FileStream fs = File.Create(nomFichier))
				{

					
					Byte[] intro = new UTF8Encoding(true).GetBytes("<< Schéma WinRelais [Bloc] >> \r\n" +
						"¤#Version\r\n" +
						"¤2·2·\r\n" +
						"EYNARD Pascal·Ingerea·\r\n" +
						"Version 2.2a Premium·\r\n" +
						"¤#PMilieu¤\r\n" +
						"4400·10000\r\n" +
						"¤#NombreSymbole¤");

					fs.Write(intro, 0, intro.Length);
				}

			}
			catch
			{
				Console.WriteLine("Erreur dans la création du fichier");
			}



		}

		// Affiche la position de chaque rangée dans le datagridview a chaque ajout de rangée
		private void DataBloc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{

			i = 0;
			while (i < DataBloc.Rows.Count)
			{
				DataBloc.Rows[i].Cells[0].Value = i + 1;
				i++;
			}
		}

		//Affiche la position de chaque rangée dans le datagridview a chaque suppression de rangée
		private void DataBloc_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			i = 0;
			while (i < DataBloc.Rows.Count)
			{
				DataBloc.Rows[i].Cells[0].Value = i + 1;
				i++;

			}

		}


		//Enregistrement du bloc 
		private void button3_Click(object sender, EventArgs e)
		{

			if (MessageBox.Show("Voulez-vous vraiment sauvegarder", " Creabloc ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				string nomReference = textBox1.Text;
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				string dossier = @"TempBloc\";
				string fullPath = path + @"\" + dossier;


				string newPath = @"S:\BE\ELECTRONIQUE\6-Outils\GenS4\Blocs\BlocsBornesAuto\";

				System.IO.File.Copy(fullPath + @"newBloc.txt", newPath + nomReference + ".xrb");

			}
		}

		//Test Largeur
		private void button7_Click(object sender, EventArgs e)
		{
			string path = @"C:\Users\beaudonnelk\Documents\Test winrelais\testlong.xrb";
			int larg = ElemBlocs.largeurBloc(path);
			Console.WriteLine("Largeur: " + larg);

		}

		void DataBloc_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (DataBloc.IsCurrentCellDirty)
			{
				// This fires the cell value changed handler below
				DataBloc.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		//Trigger quand un élément du combobox est changé
		private void DataBloc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			//index de la colone du combobox = 1 car 2eme colone dans le datadridview

			DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)DataBloc.Rows[e.RowIndex].Cells[1];

			if (e.ColumnIndex == DataBloc.Columns[1].Index)
			{
				if (cb.Value != null)
				{
					MessageBox.Show("Index");
					DataBloc.Invalidate();
				}
			}
		}




		// Permet de cliquer une seule fois pour ouvrir la liste déroulante
		private void DataBloc_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			ComboBox ctrl = e.Control as ComboBox;
			ctrl.Enter -= new EventHandler(ctrl_Enter);
			ctrl.Enter += new EventHandler(ctrl_Enter);

		}
		void ctrl_Enter(object sender, EventArgs e)
		{
			(sender as ComboBox).DroppedDown = true;
		}


		//MULTILANGUE//

		//Fonction appelé pour changer la langue
		private void ChangeLangue(string lang) 
		{
			foreach (Control c in this.Controls)
			{
				ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
				resources.ApplyResources(c, c.Name, new CultureInfo(lang));
			}
		}

		private void englishToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			//Change la langue en anglais (USA)
			language = "en-US";
			englishToolStripMenuItem.Checked = true;
			françaisToolStripMenuItem.Checked = false;

			//Sauvegarde le choix de l'utilisateur dans les paramètres
			Properties.Settings.Default.langue = "en-US";
			Properties.Settings.Default.Save();

			//Redémarage de l'application 
			Application.Restart();
		}

		private void françaisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Change la langue en français
			language = "en-US";
			englishToolStripMenuItem.Checked = false;
			françaisToolStripMenuItem.Checked = true;

			
			Properties.Settings.Default.langue = "fr-FR";
			Properties.Settings.Default.Save();

			Application.Restart();

		}
	}
	

}

